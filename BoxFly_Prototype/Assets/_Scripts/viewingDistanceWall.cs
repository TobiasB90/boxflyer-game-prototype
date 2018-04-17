using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewingDistanceWall : MonoBehaviour {

    Camera main;
    public float MaxViewingDistance;
	// Use this for initialization
	void Start () {
        main = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y, main.transform.position.z + (main.farClipPlane - 50));
	}
}
