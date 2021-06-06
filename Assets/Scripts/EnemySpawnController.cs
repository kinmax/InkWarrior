using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject enemy;
    [SerializeField] int maxEnemyCount;

    void SpawnEnemy()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemyCount)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            Instantiate(enemy, spawnPoint.position, Quaternion.identity);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0.5f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
