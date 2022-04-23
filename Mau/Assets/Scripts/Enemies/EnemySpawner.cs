using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, ISignalReciever
{
    private static Queue<GameObject> enemyQueue = null;
    private int enemyCount = 10;

    [SerializeField] GameObject enemyPrefab;

    private void Awake() {
        if (enemyQueue == null)
            enemyQueue = new Queue<GameObject>(enemyCount);
    }

    private bool activated = false;
    private int spawnChance = 100;

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
            if (Random.Range(0, 100) > spawnChance)
                return;

            if (enemyQueue.Count >= enemyCount) {
                GameObject goDestroy = enemyQueue.Dequeue();
                print(goDestroy.name + " has been dequeued and destroyed! Current Queue Count: " + enemyQueue.Count);
                Destroy(goDestroy);
            }

            GameObject newEnemy = GameObject.Instantiate(enemyPrefab);
            newEnemy.transform.parent = transform.parent.parent;
            newEnemy.transform.position = transform.position;

            newEnemy.GetComponent<SaveObject_Enemy>().SetRemoveOnLoad(true);

            int randNum = Random.Range(0, 1);
            if(randNum == 1)
            {
                newEnemy.GetComponent<EnemyMovement>().Flip();
            }

            enemyQueue.Enqueue(newEnemy);
            print(newEnemy.name + " has been enqueued! Current Queue Count: " + enemyQueue.Count);
        }
    }
}
