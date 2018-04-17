using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorcontrollerdodgeedges : MonoBehaviour {

    colormanager colormng;
    Material _material;
    public Color lerpedColor;

    // Use this for initialization
    void Start () {

        colormng = GameObject.Find("_colorManager").GetComponent<colormanager>();
        _material = GetComponent<MeshRenderer>().materials[0];

    }

    // Update is called once per frame
    void Update () {

        float step = colormng.colorchangingtime * Time.deltaTime;
        lerpedColor = Color.Lerp(_material.GetColor("_EmissionColor"), colormng._nextColor_edges, step);
        _material.SetColor("_EmissionColor", lerpedColor);

    }

}
