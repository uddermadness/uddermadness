using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {

	public bool lockCursor;
	public float mouseSensitivity = 10;
	public Transform target;
	public Vector3 cameraOffset = new Vector3(0.5f, 2f, 2.5f);
	public float dstFromTarget = 2;
	public float offsetTarget = 2;
	public Vector2 pitchMinMax = new Vector2 (-40, 85);

	public float rotationSmoothTime = .12f;
	Vector3 rotationSmoothVelocity;
	Vector3 currentRotation;

	float yaw;
	float pitch;

	void Start() {
		// option to lock and unlock cursor for testing and gameplay
		if (lockCursor) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}
	void LateUpdate () {
		Snap();
	}
	
	public void Snap()
	{
		// adjusting camera rotation, pitch and yaw to according to the mouse movements 
		yaw += Input.GetAxis ("Mouse X") * mouseSensitivity;
		pitch -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		pitch = Mathf.Clamp (pitch, pitchMinMax.x, pitchMinMax.y);
		// smoothing the camera rotation
		currentRotation = Vector3.SmoothDamp (currentRotation, new Vector3 (pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
		transform.eulerAngles = currentRotation;
		//targeting the character and setting an offset to be able to set an over the should view
		transform.position = target.position - transform.forward * cameraOffset.z + transform.right * cameraOffset.x + transform.up * cameraOffset.y;
	}

}
