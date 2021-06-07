using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanSpawnController : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject van;
    [SerializeField] InkLevelController inkLevel;
    [SerializeField] GameObject vanIsHereText;

    void SpawnVan()
    {
        if (inkLevel.getInkLevel() <= 20 && GameObject.FindGameObjectsWithTag("Van").Length == 0)
        {
            float maxDist = -1.0f;
            Transform spawnPoint = spawnPoints[0];
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            foreach (Transform t in spawnPoints)
            {
                float distance = Vector3.Distance(t.position, player.position);
                if (distance > maxDist)
                {
                    maxDist = distance;
                    spawnPoint = t;
                }
            }
            vanIsHereText.SetActive(true);
            Instantiate(van, spawnPoint.position, Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnVan", 30.0f, 30.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
