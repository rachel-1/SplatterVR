using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlobMaker : MonoBehaviour {
    public static bool shouldSpawn = true;

    public float scatterAmount = 0.01F;

    public bool gravity;

    public GameObject paintball;
    public ColorDetector colorDetector;

    CurrentColor currentColor;

    // Use this for initialization
    void Start()
    {
        GameObject colorPicker = GameObject.Find("ColorPicker");
        //currentColor = colorPicker.GetComponent<CurrentColor>();
    }

    Vector3 createSimilarVector(Vector3 v)
    {
        return new Vector3(v.x + Random.Range(-scatterAmount, scatterAmount), v.y + Random.Range(-scatterAmount, scatterAmount), v.z + Random.Range(-scatterAmount, scatterAmount));
    }

    public void createProjectilesWithNoise(float speedScale, int numVectors)
    {
        for (int i = 0; i < numVectors; i++)
        {
            createProjectile(speedScale);
            //change that to create similar instead of direction
        }
    }

    public void createProjectile(float speedScale, bool noise = false)
    {
        if (!shouldSpawn) return;
        
        var projectile = Instantiate<GameObject>(paintball);

        projectile.GetComponent<Renderer>().material.color = colorDetector.color;
        projectile.GetComponent<PainterScript>().splatColor = colorDetector.color;
        float radius = speedScale / 36;
        var radiusv = new Vector3(radius, radius, radius);
        projectile.transform.localScale = radiusv; 
        projectile.GetComponent<PainterScript>().splatSize = speedScale / 12;

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (noise)
        {
            rb.AddForce(createSimilarVector(transform.forward * speedScale), ForceMode.Impulse);
        }
        else
        {
            rb.AddForce(transform.forward * speedScale, ForceMode.Impulse);
        }
        
        if (!gravity)
        {
            rb.useGravity = false;
        }

        projectile.transform.position = transform.GetChild(1).position;

        /*
        projectile = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        
        // shrink the projectile
        projectile.transform.localScale += new Vector3(-0.99F, -0.99F, -0.95F);
        projectile.transform.position = transform.GetChild(1).position;

        projectile.AddComponent<Rigidbody>();
        projectile.AddComponent<Renderer>();
        Renderer renderer = projectile.GetComponent<Renderer>();
        Material material = new Material(Shader.Find("Diffuse"));
        material.color = new Color(0, 0, 0);
        renderer.material = material;
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward*10, ForceMode.Impulse);
        */
    }

	// Update is called once per frame
	void Update () {

	}
}
