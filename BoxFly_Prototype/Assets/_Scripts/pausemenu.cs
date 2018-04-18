using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class pausemenu : MonoBehaviour {

    public bool gameIsPaused = true;

    public GameObject pauseMenuUI;
    public GameObject retryMenuUI;
    public GameObject startMenuUI;
    public GameObject HighScore;
    public GameObject gameStatistics;
    statistics stats;

    void Start()
    {
        Time.timeScale = 0;
        gameIsPaused = true;
        stats = gameStatistics.GetComponent<statistics>();
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) && stats.alive)
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        HighScore.SetActive(false);
        pauseMenuUI.SetActive(false);
        startMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

    }

    void Pause()
    {
        HighScore.SetActive(true);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RetryGame()
    {
        HighScore.SetActive(false);
        retryMenuUI.SetActive(false);
        SceneManager.LoadScene("Level_01");
    }
}
