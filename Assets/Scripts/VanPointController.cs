using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanPointController : MonoBehaviour
{
    [SerializeField] bool vertical;
    [SerializeField] bool goesForward;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Vertical()
    {
        return this.vertical;
    }

    public bool GoesForward()
    {
        return this.goesForward;
    }
}
