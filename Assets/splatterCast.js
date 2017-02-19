var splat : GameObject;

function Update () 
{
    if (Input.GetMouseButtonDown(0))
    {
        var ray = GetComponent.<Camera>().ScreenPointToRay (Input.mousePosition);
        var hit : RaycastHit;

        if (Physics.Raycast (ray, hit, Mathf.Infinity)) 
        {
            theSplat = Instantiate (splat, hit.point + (hit.normal * 2.5), Quaternion.identity);
            Destroy (theSplat, 2);
        }
    }
}