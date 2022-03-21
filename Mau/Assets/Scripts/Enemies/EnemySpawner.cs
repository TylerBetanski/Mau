using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, ISignalReciever
{
    [SerializeField] GameObject enemyPrefab;


    public void RecieveSignal()
    {
        SpawnEnemy();  
    }

    public void SpawnEnemy()
    {
        if (enemyPrefab != null)
        {
            GameObject newEnemy = GameObject.Instantiate(enemyPrefab);
            newEnemy.transform.parent = transform;
            newEnemy.transform.position = transform.position;
        }
    }
}
