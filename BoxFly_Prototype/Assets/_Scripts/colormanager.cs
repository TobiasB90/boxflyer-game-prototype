using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colormanager : MonoBehaviour {

    [ColorUsageAttribute(true, true, 0f, 8f, 0.125f, 3f)] public Color[] colorprofiles_edges;
    [ColorUsageAttribute(true, true, 0f, 8f, 0.125f, 3f)] public Color[] colorprofiles_eq;
    public float colorchangingtime;
    public Color _nextColor_edges;
    public Color _nextColor_eq;
    public int eq_next = 1;
    public int edge_next = 1;

    // Use this for initialization
    void Start () {
        _nextColor_edges = colorprofiles_edges[1];
        _nextColor_eq = colorprofiles_eq[1];
    }

    // Update is called once per frame
    void Update () {

	}

    public IEnumerator change_edge_color(float waittime_edge)
    {
        if (edge_next + 1 == colorprofiles_edges.Length)
        {
            edge_next = 0;
            _nextColor_edges = colorprofiles_edges[edge_next];
        }
        else if (edge_next < colorprofiles_edges.Length)
        {
            edge_next++;
            _nextColor_edges = colorprofiles_edges[edge_next];
        }
        yield return new WaitForSeconds(waittime_edge);
    }

    public IEnumerator change_eq_color(float waittime_eq)
    {
        if (eq_next + 1 == colorprofiles_eq.Length)
        {
            eq_next = 0;
            _nextColor_eq = colorprofiles_eq[eq_next];
        }
        else if (eq_next < colorprofiles_eq.Length)
        {
            eq_next++;
            _nextColor_eq = colorprofiles_eq[eq_next];
        }
        yield return new WaitForSeconds(waittime_eq);
    }
}
