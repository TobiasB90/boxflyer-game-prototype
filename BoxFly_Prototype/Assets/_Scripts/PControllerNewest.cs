using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PControllerNewest : MonoBehaviour {

    public GameObject PlayerModel;
    public GameObject EndlessBuilderDestroyer;

    public float flyingspeed;
    public bool invertedmovement = true;
    public bool backToDefPos;
    public float currentVelocity;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float step = flyingspeed * Time.deltaTime;
        transform.position += PlayerModel.transform.forward * step;
        EndlessBuilderDestroyer.transform.position = new Vector3(0, 0, transform.position.z);
    }
}
