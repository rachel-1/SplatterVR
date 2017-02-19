using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentColor : MonoBehaviour {

    public Color color;

    void OnColorChange(HSBColor color)
    {
        this.color = color.ToColor();
        Debug.Log(color.ToColor());
    }

}
