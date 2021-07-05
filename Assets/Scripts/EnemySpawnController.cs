using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject enemy;
    [SerializeField] int maxEnemyCount;
    [SerializeField] float firstSpawn;
    [SerializeField] float spawnInterval;
    [SerializeField] Transform player;

    void SpawnEnemy()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemyCount)
        {
            float minDist = 1000000000.0f;
            Transform spawnPoint = spawnPoints[0].transform;
            foreach (Transform t in spawnPoints)
            {
                float distance = Vector3.Distance(t.position, player.position);
                if (distance < minDist)
                {
                    minDist = distance;
                    spawnPoint = t;
                }
                
            }
            Instantiate(enemy, spawnPoint.position, Quaternion.identity);

        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", firstSpawn, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
