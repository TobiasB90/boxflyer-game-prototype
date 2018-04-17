using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class pausemenu : MonoBehaviour {

    public bool gameIsPaused = true;

    public GameObject pauseMenuUI;
    public GameObject retryMenuUI;
    public GameObject startMenuUI;

    void Start()
    {
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
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
        pauseMenuUI.SetActive(false);
        startMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

    }

    void Pause()
    {
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
        retryMenuUI.SetActive(false);
        SceneManager.LoadScene("Level_01");
    }
}
