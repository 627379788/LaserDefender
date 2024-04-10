using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WaveConfig", fileName = "NewWaveConfig")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] List<GameObject> Enemies;
    [SerializeField] float timeBetweenEnemy = 1f;
    [SerializeField] float spawnTimeVariance = 0.5f;
    [SerializeField] float minimumSpawnTime = 0.25f;

    public int GetEnemiesCount() {
        return Enemies.Count;
    }
    public GameObject GetEnemyById(int id) {
        return Enemies[id];
    }
    public float GetMoveSpeed() {
        return moveSpeed;
    }

    public List<Transform> GetWayPoints() {
        List<Transform> list = new List<Transform>();
        foreach(Transform transform in pathPrefab) {
            list.Add(transform); 
        }
        return list;
    }
    
    public Transform GetStartWaypoint() {
        return pathPrefab.GetChild(0);
    }
    
    public float GetRandomTimeBetweenEnemy() {
        return Mathf.Clamp(UnityEngine.Random.Range(timeBetweenEnemy, spawnTimeVariance), minimumSpawnTime, float.MaxValue);
    }
}
