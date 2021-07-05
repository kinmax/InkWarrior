using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanSpawnController : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] GameObject van;
    [SerializeField] InkLevelController inkLevel;
    [SerializeField] GameObject vanIsHereText;
    [SerializeField] float interval;
    [SerializeField] AudioSource hornFX;
    [SerializeField] AudioSource leaveFX;
    GameObject currentPoint;
    Vector3 originalPos;

    void SpawnVan()
    {
        if (inkLevel.getInkLevel() <= 20 && GameObject.FindGameObjectsWithTag("Van").Length == 0)
        {
            float maxDist = -1.0f;
            currentPoint = null;
            Transform spawnPoint = spawnPoints[0].transform;
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            foreach (GameObject o in spawnPoints)
            {
                Transform t = o.transform;
                float distance = Vector3.Distance(t.position, player.position);
                if (distance > maxDist)
                {
                    currentPoint = o;
                    maxDist = distance;
                    spawnPoint = t;
                }
            }
            vanIsHereText.SetActive(true);
            VanPointController comp = currentPoint.GetComponent(typeof(VanPointController)) as VanPointController;
            hornFX.Play();
            GameObject vanInst = Instantiate(van, spawnPoint.position, Quaternion.identity);
            if (comp.Vertical())
            {
                vanInst.transform.rotation = Quaternion.Euler(0, 0, 270.0f);
            }
        }
    }

    public void DestroyVan()
    {
        leaveFX.Play();
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        InvokeRepeating("MoveVan", 0.1f, 0.001f);
        GameObject v = GameObject.FindGameObjectWithTag("Van");
        Destroy(v, 3.0f);
    }   

    public void MoveVan()
    {
        GameObject v = GameObject.FindGameObjectWithTag("Van");
        if(v == null)
        {
            CancelInvoke("MoveVan");
        }
        Vector2 move = new Vector2();
        VanPointController comp = currentPoint.GetComponent(typeof(VanPointController)) as VanPointController;
        move.x = 1.0f;
        move.y = 0.0f;
        if(comp.GoesForward())
        {
            move.x = -move.x;
            move.y = -move.y;
        }
        
        float moveSpeed = 3.0f;
        v.transform.Translate(move * Time.deltaTime * moveSpeed);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnVan", interval, interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
