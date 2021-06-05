using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveriesController : MonoBehaviour
{
    int currentPoint;
    int deliveriesLeft;
    [SerializeField] int inkPerPoint;
    [SerializeField] Transform[] deliveryPoints;
    [SerializeField] GameObject deliveryIndicator;
    [SerializeField] InkLevelController inkLevel;

    void ShowIndicator()
    {
        if(deliveriesLeft > 0)
        {
            Transform point = deliveryPoints[currentPoint];
            Instantiate(deliveryIndicator, new Vector3(point.position.x + 1.0f, point.position.y), Quaternion.identity);
        }
    }

    bool PlayerInRange()
    {
        if (deliveriesLeft > 0)
        {
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            Debug.Log("Deliver - Player in Range - " + Vector3.Distance(deliveryPoints[currentPoint].position, player.position));
            return (Vector3.Distance(deliveryPoints[currentPoint].position, player.position) < 1.0f);
        }

        return false;
    }

    public int DeliveriesLeft()
    {
        return deliveriesLeft;
    }

    bool EnoughInk()
    {
        if(deliveriesLeft > 1)
        {
            return (inkLevel.getInkLevel() > inkPerPoint);
        }
        else if(deliveriesLeft == 1)
        {
            return (inkLevel.getInkLevel() >= inkPerPoint);
        }
        return false;
    }

    public bool Deliver()
    {
        Debug.Log("Deliver");
        if(PlayerInRange() && deliveriesLeft > 0 && EnoughInk())
        {
            Debug.Log("Deliver - Going to Deliver");
            currentPoint++;
            deliveriesLeft--;
            GameObject indicator = GameObject.FindGameObjectWithTag("DeliveryIndicator");
            Destroy(indicator);
            inkLevel.Subtract(inkPerPoint);
            ShowIndicator();
            return true;
        }

        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentPoint = 0;
        deliveriesLeft = deliveryPoints.Length;
        ShowIndicator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
