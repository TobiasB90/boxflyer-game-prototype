using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class statistics : MonoBehaviour {

    public float Timer = 0;
    public float Score = 0;
    public float ScoreMultiplier = 50;
    public bool playing = true;
    public Text HighScoreTXT;

    // Use this for initialization
    void Start () {
        Timer = 0;
        Score = 0;
        playing = true;
        HighScoreTXT.text = "HIGHSCORE: " + Mathf.Round(PlayerPrefs.GetFloat("HighScore", 0)).ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if (playing)
        {
            Timer += Time.deltaTime;
            Score = Timer * ScoreMultiplier;
        }
	}

    public void Retry()
    {
        SceneManager.LoadScene("Level_01");
    }

    public void UpdateHighScore()
    {
        HighScoreTXT.text = "HIGHSCORE: " + Mathf.Round(PlayerPrefs.GetFloat("HighScore", 0)).ToString();
    }
}
