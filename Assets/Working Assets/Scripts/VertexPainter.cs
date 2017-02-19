using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexPainter : MonoBehaviour {


    public float splatSize;
    public Color splatColor;

	void Start () {
        var mesh = GetComponent<MeshFilter>().mesh;

        var colors = new Color[mesh.vertices.Length];

        for (int i = 0; i < colors.Length; i++)
            colors[i] = splatColor;

        mesh.colors = colors;

        /*
        GetComponent<Transform>().localScale = new Vector3(
            splatSize, splatSize, splatSize
        );
        */
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
