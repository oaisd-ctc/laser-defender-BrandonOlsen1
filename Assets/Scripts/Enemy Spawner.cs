using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] WaveConfigSO currentWave;

    
    void Start()
    {
        SpawnEnemies();
    }



    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    
    void SpawnEnemies()
    {
        Instantiate(currentWave.GetEnemyPrefabs(0),currentWave.GetStartingWaypoint().position, Quaternion.identity);
    }







}
