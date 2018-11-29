using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeam : MonoBehaviour {

    public Transform startPoint;
    public Transform endPoint;
    LineRenderer lightBeamLine;

    public float startWidth;
    public float endWidth;

    // Use this for initialization
    void Start ()
    {
        lightBeamLine = GetComponent<LineRenderer>();
        lightBeamLine.startWidth = startWidth;
        lightBeamLine.endWidth = endWidth;
    }
	
	// Update is called once per frame
	void Update ()
    {
        lightBeamLine.SetPosition(0, startPoint.position);
        lightBeamLine.SetPosition(1, endPoint.position);
    }
}
