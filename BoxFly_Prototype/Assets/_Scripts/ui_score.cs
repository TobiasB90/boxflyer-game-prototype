using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ui_score : MonoBehaviour {

    statistics stats;
    Text scrText;
	// Use this for initialization
	void Start () {
        stats = GameObject.Find("_gameStatistics").GetComponent<statistics>();
        scrText = this.gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        scrText.text = "Score: " + Mathf.Round(stats.Score);
	}
}
