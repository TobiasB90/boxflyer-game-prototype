using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

    public GameObject Player;
    public float DistanceToPlayer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void OnTriggerEnter(Collider col)
    {
        Destroy(col.gameObject);
    }
}
