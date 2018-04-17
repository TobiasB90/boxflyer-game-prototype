using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colormanager : MonoBehaviour {

    [ColorUsageAttribute(true, true, 0f, 8f, 0.125f, 3f)] public Color[] colorprofiles_edges;

    public float colorchangingtime;
    public Color _nextColor_edges;
    public int edge_next = 1;

    // Use this for initialization
    void Start () {
        _nextColor_edges = colorprofiles_edges[1];
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
}
