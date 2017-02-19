using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorTest : MonoBehaviour {

    public ColorDetector colorDetector;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Renderer>().material.color = colorDetector.color;
    }
}
