using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    [SerializeField] float speed;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        int n = Random.Range(1, 5);
        sprite = GetComponent<SpriteRenderer>();
        switch(n)
        {
            case 1: sprite.material.SetColor("_Color", Color.black); break;
            case 2: sprite.material.SetColor("_Color", Color.yellow); break;
            case 3: sprite.material.SetColor("_Color", Color.cyan); break;
            case 4: sprite.material.SetColor("_Color", Color.magenta); break;

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
