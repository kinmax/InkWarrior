using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkLevelController : MonoBehaviour
{
    private int level;
    [SerializeField] GameObject notEnoughInkText;
    [SerializeField] int refillMin, refillMax;

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
        notEnoughInkText.SetActive(false);
        int min = level > refillMin ? refillMin : level;
        int newLevel = Random.Range(min, refillMax);
        level = newLevel;
    }

    public void Damage()
    {
        if(level == 0)
        {
            level = -1;
        }
        else
        {
            if (level > 5)
            {
                level -= 5;
            }
            else
            {
                level = 0;
            }
        }        
    }
}
