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
    [SerializeField] GameObject notEnoughInkText;

    void ShowIndicator()
    {
        if(deliveriesLeft > 0)
        {
            Transform point = deliveryPoints[currentPoint];
            Instantiate(deliveryIndicator, new Vector3(point.position.x+0.2f, point.position.y+1f), Quaternion.identity);
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

    public int TotalDeliveries()
    {
        return deliveryPoints.Length;
    }

    public Transform CurrentDeliveryPoint()
    {
        if(deliveriesLeft > 0)
        {
            return this.deliveryPoints[currentPoint];
        }
        return this.deliveryPoints[this.deliveryPoints.Length - 1];
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
        if(PlayerInRange() && deliveriesLeft > 0 && EnoughInk())
        {
            currentPoint++;
            deliveriesLeft--;
            GameObject indicator = GameObject.FindGameObjectWithTag("DeliveryIndicator");
            Destroy(indicator);
            inkLevel.Subtract(inkPerPoint);
            ShowIndicator();
            return true;
        }
        else if(PlayerInRange() && deliveriesLeft > 0 && !EnoughInk())
        {
            notEnoughInkText.SetActive(true);
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
