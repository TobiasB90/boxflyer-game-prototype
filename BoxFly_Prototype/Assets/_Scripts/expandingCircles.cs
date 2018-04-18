using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expandingCircles : MonoBehaviour {

    public float ExpandingSpeed;
    public Vector3 TargetSize;
    public float InvokeDelay;

	// Use this for initialization
	public void Start () {
        Invoke("ScaleObj", InvokeDelay);
    }

    // Update is called once per frame
    void Update () {

    }

    void ScaleObj()
    {
        transform.DOScale(TargetSize, ExpandingSpeed * Time.deltaTime);
    }
}
