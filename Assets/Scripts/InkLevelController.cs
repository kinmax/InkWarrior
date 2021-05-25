using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkLevelController : MonoBehaviour
{
    private int level;
    // Start is called before the first frame update
    void Start()
    {
        level = 100;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public int getInkLevel()
    {
        return level;
    }

    public bool shoot()
    {
        if((level - 1) >= 0)
        {
            level = level - 1;
            return true;
        }

        return false;
    }
}
