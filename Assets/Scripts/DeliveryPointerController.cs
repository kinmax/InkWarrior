using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPointerController : MonoBehaviour
{
    GameObject player;
    [SerializeField] DeliveriesController deliveriesController;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Point();
    }

    void Point()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 deliveryPosition = deliveriesController.CurrentDeliveryPoint().position;

        Vector2 offset = new Vector2(playerPosition.x - deliveryPosition.x, playerPosition.y - deliveryPosition.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
