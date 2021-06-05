using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryCountController : MonoBehaviour
{
    [SerializeField] DeliveriesController deliveries;
    Text txt;
    // Start is called before the first frame update
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        txt.text = "DELIVERIES: " + deliveries.DeliveriesLeft() + "/" + deliveries.TotalDeliveries();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "DELIVERIES LEFT: " + deliveries.DeliveriesLeft();
    }
}
