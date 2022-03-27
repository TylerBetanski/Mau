using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, ISignalReciever
{
    [SerializeField] GameObject enemyPrefab;

    private bool activated = false;

    public void RecieveSignal()
    {
        activated = !activated;

        if(activated)
            SpawnEnemy();  
    }

    public void SpawnEnemy()
    {
        if (enemyPrefab != null)
        {
            GameObject newEnemy = GameObject.Instantiate(enemyPrefab);
            newEnemy.transform.parent = transform.parent.parent;
            newEnemy.transform.position = transform.position;

            newEnemy.GetComponent<SaveObject_Enemy>().SetRemoveOnLoad(true);

            int randNum = Random.Range(0, 1);
            if(randNum == 1)
            {
                newEnemy.GetComponent<EnemyMovement>().Flip();
            }

        }
    }
}
