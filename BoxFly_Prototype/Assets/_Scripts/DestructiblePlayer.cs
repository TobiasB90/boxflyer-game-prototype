using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestructiblePlayer : MonoBehaviour {

    public GameObject ShatteredPlayer;
    public GameObject Player;
    public GameObject RetryButton;
    public GameObject Canvas;
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
        stats.playing = false;
        Instantiate(ShatteredPlayer, transform.position, transform.rotation);
        var button = Instantiate(RetryButton);
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(stats.Retry);
        button.transform.SetParent(Canvas.transform, false);
        Destroy(Player);
    }
}
