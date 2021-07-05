using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    SpriteRenderer sprite;
    public GameObject shot;
    public Transform spawnShot;
    public InkLevelController inkLevel;
    [SerializeField] GameController gameController;
    AudioSource shootFX;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        shootFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameController.IsPaused())
        {
            Aim();
            Shoot();
        }
    }

    void Aim()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mousePosition.x - screenPoint.x, mousePosition.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        sprite.flipY = (mousePosition.x < screenPoint.x);
    }

    void Shoot()
    {
        if(Input.GetButtonDown("Fire1") && inkLevel.shoot())
        {
            Instantiate(shot, spawnShot.position, transform.rotation);
            shootFX.Play();
        }
    }
}
