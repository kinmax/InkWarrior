using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] InkLevelController inkLevel;
    [SerializeField] DeliveriesController deliveries;
    bool paused;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool IsPaused()
    {
        return this.paused;
    }

    void LevelCleared()
    {

    }

    void GameOver()
    {

    }

    void Pause()
    {
        this.paused = true;
    }

    void Resume()
    {
        this.paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(deliveries.DeliveriesLeft() == 0)
        {
            LevelCleared();
        }
        else if(inkLevel.getInkLevel() <= 0)
        {
            GameOver();
        }
        else if(Input.GetButtonDown("Cancel"))
        {
            if(paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        // otherwise just go on
    }
}
