using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserDisabler : MonoBehaviour
{
    //for hand 1 only
    public void enableLaser()
    {
        var laser = gameObject.AddComponent<SteamVR_LaserPointer>();
        laser.color = Color.blue;
        Debug.Log("activating laserpointer");
    }

    public void disableLaser()
    {
        DestroyImmediate(gameObject.GetComponent<SteamVR_LaserPointer>());
        Debug.Log("disabling laserpointer");
    }
}
