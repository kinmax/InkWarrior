using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed;
    GameObject player;
    Animator anim;
    SpriteRenderer sprite;
    bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null && isAlive)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            CheckFlip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {             
        if(collision.CompareTag("Shot"))
        {
            SpriteRenderer shotSprite = collision.GetComponentInParent<SpriteRenderer>();
            anim.SetTrigger("dead");
            sprite.material.SetColor("_Color", shotSprite.material.color);
            isAlive = false;
            Destroy(gameObject, 0.5f);
        }
    }

    void CheckFlip()
    {
        
        Vector3 playerPosition = player.transform.position;
        Vector3 enemyPosition = transform.position;
 
        sprite.flipX = (playerPosition.x < enemyPosition.x);
    }

}
