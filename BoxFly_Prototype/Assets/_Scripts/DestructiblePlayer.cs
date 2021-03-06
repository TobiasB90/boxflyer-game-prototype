﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestructiblePlayer : MonoBehaviour {

    public GameObject ShatteredPlayer;
    public GameObject Player;
    public GameObject Canvas;
    public GameObject retryMenuUI;
    public GameObject HighScore;
    statistics stats;
	// Use this for initialization
	void Start () {
        stats = GameObject.Find("_gameStatistics").GetComponent<statistics>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (stats.Score > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", stats.Score);
            stats.UpdateHighScore();
        }
        stats.playing = false;
        Instantiate(ShatteredPlayer, transform.position, transform.rotation);
        Destroy(Player);
        retryMenuUI.SetActive(true);
        HighScore.SetActive(true);
        stats.alive = false;
    }
}
