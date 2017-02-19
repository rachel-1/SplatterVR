using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushTip : MonoBehaviour {

	// Use this for initialization
    public GameObject paintball;
    public ColorDetector colorDetector;

    public SteamVR_TrackedObject controller;

    void Start () {
        GameObject colorPicker = GameObject.Find("ColorPicker");
    }
	
	// Update is called once per frame
	void Update () {
       this.GetComponent<Renderer>().material.color = colorDetector.color;

        /*
        var device = SteamVR_Controller.Input((int)controller.index);

        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            var touchpad = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);

            Debug.Log("x: " + touchpad.x + ", y: " + touchpad.y);
        }
        */
    }
}
