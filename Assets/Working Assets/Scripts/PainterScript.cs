using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Generate paint decals
/// </summary>
public class PainterScript : MonoBehaviour
{
	/// <summary>
	/// A single paint decal to instantiate
	/// </summary>
	public Transform PaintPrefab;

    public Color splatColor;
    public float splatSize;

	// DEBUG
	private bool mDrawDebug;
	private Vector3 mHitPoint;
	private List<Ray> mRaysDebug = new List<Ray>();

	void Awake()
	{
		if (PaintPrefab == null) Debug.LogError("Missing Paint decal prefab!");
	}

	void Update()
	{
	}

    private void OnCollisionEnter(Collision collision)
    {
        var p = collision.contacts.First();
        if (p.otherCollider.gameObject.tag == "Paintable")
        {
            var n = p.normal.normalized;

            var paintSplatterObj = GameObject.Instantiate(PaintPrefab,
                    p.point,

                    // Rotation from the original sprite to the normal
                    // Prefab are currently oriented to z+ so we use the opposite
                    Quaternion.FromToRotation(Vector3.back, p.normal)
                );

            var painter = paintSplatterObj.GetComponent<VertexPainter>();
            
            painter.splatColor = splatColor;
            painter.splatSize = splatSize;

            Transform paintSplatter = paintSplatterObj.transform;

            paintSplatterObj.GetComponent<Renderer>().material.color
                = new Color(Random.Range(0, 1), Random.Range(0, 1), Random.Range(0, 1));

            // Random scale
            var scaler = splatSize;

            paintSplatter.localScale = new Vector3(
                paintSplatter.localScale.x * scaler,
                paintSplatter.localScale.y * scaler,
                paintSplatter.localScale.z
            );

            // Random rotation effect
            var rater = Random.Range(0, 360);
            paintSplatter.transform.RotateAround(p.point, p.normal, rater);

            Destroy(gameObject);
        }
    }

	void OnDrawGizmos()
	{
		// DEBUG
		if (mDrawDebug)
		{
			Gizmos.DrawSphere(mHitPoint, 0.2f);
			foreach (var r in mRaysDebug)
			{
				Gizmos.DrawRay(r);
			}
		}
	}
}

