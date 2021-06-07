using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryIndicatorController : MonoBehaviour
{
    private Vector3 scaleChange;

    void ChangeScale()
    {
        this.gameObject.transform.localScale += scaleChange;

        if (this.gameObject.transform.localScale.y < 0.09f || this.gameObject.transform.localScale.y > 0.15f)
        {
            scaleChange = -scaleChange;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);
        InvokeRepeating("ChangeScale", 0.0f, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
