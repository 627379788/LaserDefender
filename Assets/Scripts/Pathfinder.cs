using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    WaveConfig waveConfig;
    EnemySpawner enemySpawner;
    List<Transform> wayPoints;
    int wayPointIndex = 0;
    void Awake() {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }
    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWaveConfig();
        wayPoints = waveConfig.GetWayPoints();
        transform.position = waveConfig.GetStartWaypoint().position;
    }

    void Update()
    {
        FollowPoint();
    }

    void FollowPoint() {
        if(wayPointIndex < wayPoints.Count) {
            Vector3 targetPoint = wayPoints[wayPointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPoint, delta);
            if(transform.position == targetPoint) {
                wayPointIndex++;
            }
        }else {
            Destroy(gameObject);
        }
    }
}
