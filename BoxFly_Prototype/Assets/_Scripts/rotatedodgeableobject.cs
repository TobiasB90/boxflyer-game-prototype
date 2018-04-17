using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatedodgeableobject : MonoBehaviour {

    public float rotationspeed = 1;
    public bool isedge;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
            transform.Rotate(0, 0, rotationspeed * Time.deltaTime);
    }
}
