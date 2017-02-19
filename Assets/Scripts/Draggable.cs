using UnityEngine;

public class Draggable : MonoBehaviour
{

    //SteamVR_TrackedObject rightController;
    public Valve.VR.InteractionSystem.Hand rightController;
    public Transform minBound;

	public bool fixX;
	public bool fixY;
	public Transform thumb;	
	bool dragging;
    Collider myCollider;

    void Start()
    {
        myCollider = GetComponent<Collider>();
        //rightController = rightHand;
    }

	void FixedUpdate()
	{
        //SteamVR_Controller.Device device = SteamVR_Controller.Input((int)rightController.index);
        //SteamVR_Controller.Device device = rightController.controller;

        //if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger)) {
        if (rightController.GetStandardInteractionButtonDown()) {
            dragging = false;
            Ray ray = new Ray(rightController.transform.position, rightController.transform.forward);
			RaycastHit hit;
			if (myCollider.Raycast(ray, out hit, 100)) {
				dragging = true;
			}
		}
        //if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger)) dragging = false;
        if (rightController.GetStandardInteractionButtonUp()) dragging = false;
        if (rightController.GetStandardInteractionButton()) {
            // if (dragging && device.GetTouch(SteamVR_Controller.ButtonMask.Trigger)) {
            Ray ray = new Ray(rightController.transform.position, rightController.transform.forward);
            RaycastHit hit;
            if (myCollider.Raycast(ray, out hit, 100))
            {
                var point = hit.point;  //Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //point = myCollider.ClosestPointOnBounds(point);
                SetThumbPosition(point);
                BoxCollider boxCollider = GetComponent<BoxCollider>();
                SendMessage("OnDrag", Vector3.one - (thumb.localPosition - minBound.localPosition) / boxCollider.size.x);
            }
		}
	}

	void SetDragPoint(Vector3 point)
	{
        if (dragging)
        {
            myCollider = GetComponent<Collider>();
            point = (Vector3.one - point) * myCollider.bounds.size.x + myCollider.bounds.min;
            SetThumbPosition(point);
        }
	}

	void SetThumbPosition(Vector3 point)
	{
        Vector3 temp = thumb.localPosition;
        thumb.position = point;
		thumb.localPosition = new Vector3(fixX ? temp.x : thumb.localPosition.x, fixY ? temp.y : thumb.localPosition.y, thumb.localPosition.z - 1);
	}
}
