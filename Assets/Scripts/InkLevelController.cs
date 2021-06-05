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
        if(level >= 5)
        {
            level -= 5;
            return true;
        }
        else if(level > 0)
        {
            level = 0;
            return true;
        }

        return false;
    }

    public void Subtract(int l)
    {
        this.level -= l;
    }

    public void Refill()
    {
        int newLevel = Random.Range(0, 100-level);
        level = newLevel;
    }
}
