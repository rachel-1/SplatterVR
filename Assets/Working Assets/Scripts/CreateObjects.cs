using System.Collections;
using UnityEngine;


public class CreateObjects : MonoBehaviour {
	public GameObject paintball;

	const float scatterAmount = 0.2F;

	// Use this for initialization
	void Start () {
	}

    void Update()
    {
        StartCoroutine("spawnPaintballs");
    }

    IEnumerator spawnPaintballs()
    {
        while (true)
        {
            Vector3 v1 = new Vector3(0, 0, 0);
            Color color = new Color(0, 0, 0);
            createProjectilesWithNoise(v1, color, 3);
            yield return new WaitForSeconds(10);
        }
    }

	Vector3 createSimilarVector(Vector3 v)
	{
		return new Vector3(
			v.x + Random.Range(-scatterAmount, scatterAmount),
			v.y + Random.Range(-scatterAmount, scatterAmount),
			v.z + Random.Range(-scatterAmount, scatterAmount)
		);
	}

	void createProjectilesWithNoise(Vector3 v, Color color, int numVectors)
	{
		for (int i = 0; i < numVectors; i++)
		{
			createProjectiles(createSimilarVector(v), color);
		}
	}

	void createProjectiles(Vector3 v, Color color)
	{
	    GameObject projectile = Instantiate(paintball);
        projectile.GetComponent<Rigidbody>().AddForce(v, ForceMode.Impulse);
	}
}