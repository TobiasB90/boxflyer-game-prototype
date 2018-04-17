using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorcontrollereq : MonoBehaviour {

    colormanager colormng;
    Material _material;
    public GameObject _exampleObject;
    Material _example;
    public Color lerpedColor;
    [ColorUsageAttribute(true, true, 0f, 8f, 0.125f, 3f)] public Color[] colorprofiles;
    Renderer[] renderers;

    // Use this for initialization
    void Start () {
        colormng = GameObject.Find("_colorManager").GetComponent<colormanager>();
        _example = _exampleObject.GetComponent<MeshRenderer>().materials[0];
        renderers = GetComponentsInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update () {
        float step = colormng.colorchangingtime * Time.deltaTime;
        lerpedColor = Color.Lerp(_example.GetColor("_EmissionColor"), colormng._nextColor_eq, step);
        if (_example.GetColor("_EmissionColor") == colormng._nextColor_eq)
        {
            StartCoroutine(colormng.change_eq_color(1));
        }

        foreach (Renderer r in renderers)
        {
            foreach (Material _material in r.materials)
            {
                if (_material.HasProperty("_EmissionColor"))
                    _material.SetColor("_EmissionColor", lerpedColor);
            }
        }
    }

}
