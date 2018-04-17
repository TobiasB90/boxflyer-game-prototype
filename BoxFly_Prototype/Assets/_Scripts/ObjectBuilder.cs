using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBuilder : MonoBehaviour {

    public GameObject[] TunnelSystems;
    public GameObject Environment;
    public GameObject FlyingObject;
    public float TunnelLength = 900;
    public float timesbuilt = 0;

    // Use this for initialization
    void Start () {
        StartCoroutine(spawnshit(1));
    }

    // Update is called once per frame
    void Update () {
        if (FlyingObject.transform.position.z >= timesbuilt * TunnelLength)
        {
            StartCoroutine(spawnshit(1));
        }
    }

    IEnumerator spawnshit(float waittime)
    {
        GameObject NewTunnel = Instantiate(TunnelSystems[Random.Range(0, TunnelSystems.Length)], transform.position, transform.rotation);
        NewTunnel.transform.parent = Environment.transform;
        timesbuilt += 1;
        yield return new WaitForSeconds(waittime);
    }
}
