using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] InkLevelController inkLevel;
    [SerializeField] DeliveriesController deliveries;
    [SerializeField] GameObject PauseMenuUI;
    [SerializeField] GameObject GameOverUI;
    [SerializeField] GameObject LevelClearedUI;
    [SerializeField] AudioSource audio;
    bool paused, gameOver;

    // Start is called before the first frame update
    void Start()
    {
        LevelClearedUI.SetActive(false);
        PauseMenuUI.SetActive(false);
        GameOverUI.SetActive(false);
        this.paused = false;
        this.gameOver = false;
        Time.timeScale = 1f;
    }

    public bool IsPaused()
    {
        return this.paused;
    }

    public void NextLevel()
    {
        LevelClearedUI.SetActive(false);
        this.paused = false;
        this.gameOver = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitToMenu()
    {
        LevelClearedUI.SetActive(false);
        GameOverUI.SetActive(false);
        this.paused = false;
        this.gameOver = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    void LevelCleared()
    {
        LevelClearedUI.SetActive(true);
        this.paused = true;
        this.gameOver = true;
        Time.timeScale = 0f;
    }

    public void RestartAfterLevelCleared()
    {
        LevelClearedUI.SetActive(false);
        this.paused = false;
        this.gameOver = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RestartAfterGameOver()
    {
        GameOverUI.SetActive(false);
        this.paused = false;
        this.gameOver = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void GameOver()
    {
        GameOverUI.SetActive(true);
        this.paused = true;
        this.gameOver = true;
        Time.timeScale = 0f;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        this.paused = true;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        this.paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(deliveries.DeliveriesLeft() == 0)
        {
            LevelCleared();
        }
        else if(inkLevel.getInkLevel() < 0)
        {
            GameOver();
        }
        else if(Input.GetButtonDown("Cancel") && !gameOver)
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
