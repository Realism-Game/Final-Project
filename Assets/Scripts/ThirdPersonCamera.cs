using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
  public bool lockCursor;
    //was 10 sensitive
	private float mouseSensitivity = 3;
	public Transform target;
	private float dstFromTarget = 2;
	private Vector2 pitchMinMax = new Vector2 (-15, 55);

	//was .12f smooth
	private float rotationSmoothTime = 1;
	Vector3 rotationSmoothVelocity;
	Vector3 currentRotation;

	float yaw;
	float pitch;

	void Start() {
		if (lockCursor) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}

	void LateUpdate () {
		float camRate = (InGameCamera.camRate == 0) ? CameraTurnRate.cameraRate : InGameCamera.camRate/10;
		mouseSensitivity = camRate; // Use camera slider value
		yaw += Input.GetAxis ("Mouse X") * mouseSensitivity;
		pitch -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		pitch = Mathf.Clamp (pitch, pitchMinMax.x, pitchMinMax.y);

		currentRotation = Vector3.SmoothDamp (currentRotation, new Vector3 (pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
		transform.eulerAngles = currentRotation;

		transform.position = target.position - transform.forward * 2 + transform.up * 0.7f;

	}
}
