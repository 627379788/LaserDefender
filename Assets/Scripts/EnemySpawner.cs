using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    WaveConfig currentWaveConfig;
    [SerializeField] float timeBetweenEnemySpawns = 2f;
    [SerializeField] bool isLoop = false;

    void Start()
    {
        StartCoroutine(SpawnEnemiesWaves()); 
    }

    IEnumerator SpawnEnemiesWaves()
    {
        do {
            foreach(WaveConfig waveConfig in waveConfigs) {
            currentWaveConfig = waveConfig;
            for(int i = 0; i < currentWaveConfig.GetEnemiesCount(); i++) {
                Instantiate(currentWaveConfig.GetEnemyById(i), currentWaveConfig.GetStartWaypoint().position, Quaternion.Euler(0, 0, 180), transform);
                yield return new WaitForSeconds(currentWaveConfig.GetRandomTimeBetweenEnemy());
            }
            yield return new WaitForSeconds(GetRandomTimeBetweenWaveConfig());
            }
        }while(isLoop);
    }
  
    private float GetRandomTimeBetweenWaveConfig()
    {
        return Mathf.Clamp(UnityEngine.Random.Range(1, timeBetweenEnemySpawns), 0.5f, float.MaxValue);
    }

    public WaveConfig GetCurrentWaveConfig() {
        return currentWaveConfig;
    }
}
