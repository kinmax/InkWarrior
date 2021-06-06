using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] InkLevelController inkLevel;
    [SerializeField] DeliveriesController deliveries;
    
    Animator anim;
    SpriteRenderer sprite;
    Material mWhite;
    Material mDefault;

    Vector2 moveInput;
    
    float timer;
    bool invencible = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        mDefault = sprite.material;
        mWhite = Resources.Load("mWhite", typeof(Material)) as Material;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            invencible = false;
        }
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        transform.Translate(moveInput * Time.deltaTime * moveSpeed);

        anim.SetBool("isMoving", (moveInput.x != 0 || moveInput.y != 0));
        CheckFlip();
        
        if(Input.GetButtonDown("Fire3") && InDistanceFromVan())
        {
            GameObject van = GameObject.FindGameObjectWithTag("Van");
            inkLevel.Refill();
            Destroy(van, 0.5f);
        }
        if(Input.GetButtonDown("Jump"))
        {
            deliveries.Deliver();
        }

        if(inkLevel.getInkLevel() < 0)
        {
            Time.timeScale = 0;
            Destroy(gameObject);
        }
    }

    bool InDistanceFromVan()
    {
        GameObject van = GameObject.FindGameObjectWithTag("Van");
        if (van == null)
        {
            return false;
        }
        float distance = Vector3.Distance(this.gameObject.transform.position, van.transform.position);
        return (distance < 5.0f);
    }

    void CheckFlip()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        sprite.flipX = (mousePosition.x < screenPoint.x);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {
            if (!invencible)
            {
                StartCoroutine("Flash");
                InvenciblePeriod();
                inkLevel.Damage();
            }
        }
    }

    void InvenciblePeriod()
    {
        timer = 1;
        if(timer > 0)
        {
            invencible = true;
        }
    }

    IEnumerator Flash()
    {
        yield return new WaitForSeconds(0.25f);
        sprite.material = mWhite;
        Invoke("ResetMaterial", 0.15f);
    }

    void ResetMaterial()
    {
        sprite.material = mDefault;
    }

}
