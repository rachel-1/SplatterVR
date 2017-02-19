using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorDisabler : MonoBehaviour {

    //for hand 2 only
	public void disablePalette()
    {
        transform.Find("ColorPicker").gameObject.SetActive(false);
    }

    public void enablePalette()
    {
        transform.Find("ColorPicker").gameObject.SetActive(true);
    }
}
