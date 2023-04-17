using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;

    int waypointIndex = 0;


     void Awake() 
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }




void Start()
{
    waveConfig = enemySpawner.GetCurrentWave();
    waypoints = waveConfig.GetWaypoint();
    transform.position = waypoints[waypointIndex].position;
}

void Update()
{
    Followpath();
}


    void Followpath()
    {
        if(waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                    waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }




    }


}
