using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] InkLevelController inkLevel;
    [SerializeField] DeliveriesController deliveries;
    Vector2 moveInput;
    Animator anim;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    bool InDistanceFromVan()
    {
        GameObject van = GameObject.FindGameObjectWithTag("Van");
        if(van == null)
        {
            return false;
        }
        float distance = Vector3.Distance(this.gameObject.transform.position, van.transform.position);
        return (distance < 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    void CheckFlip()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        sprite.flipX = (mousePosition.x < screenPoint.x);
    }
}
