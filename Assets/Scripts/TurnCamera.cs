using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCamera : MonoBehaviour {

	public float positionDamp;
	public float rotationDamp;
	private Transform cameraTransform;

	// Update is called once per frame
	void Update () {
		if (Camera.main.transform != cameraTransform) {
			Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, cameraTransform.position, Time.deltaTime * positionDamp);
			Camera.main.transform.rotation = Quaternion.Slerp (Camera.main.transform.rotation, cameraTransform.rotation, Time.deltaTime * rotationDamp);
		}
	}

	public void SetCameraPosRot(Transform cameraTransform)
	{
		this.cameraTransform = cameraTransform;
	}
}
