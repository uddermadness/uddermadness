using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {

	public bool lockCursor;
	public float mouseSensitivity = 0.125f;
	public Transform target;
	public float dstFromTarget = 2;
	public Vector2 pitchMinMax = new Vector2 (-40, 50);
	public Vector3 offset;

	public float rotationSmoothTime = .12f;
	Vector3 rotationSmoothVelocity;
	Vector3 currentRotation;

	float yaw;
	float pitch;

	void Start() {
		// this is to lock and make the cursor(mouse) invisible
		if (lockCursor) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}

	void LateUpdate () {
		// the sensitivity of the mouse
		yaw += Input.GetAxis ("Mouse X") * mouseSensitivity;
		pitch -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		pitch = Mathf.Clamp (pitch, pitchMinMax.x, pitchMinMax.y);

		currentRotation = Vector3.SmoothDamp (currentRotation, new Vector3 (pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
		transform.eulerAngles = currentRotation;

		// problem make the camer rotate the characeter

		transform.position = target.position - transform.forward * dstFromTarget;

		// this is to ofset the camera from the caracter
		// Vector3 desiredPosition = target.position + offset;
        // Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, mouseSensitivity);
        // transform.position = smoothedPosition;

	}

}
