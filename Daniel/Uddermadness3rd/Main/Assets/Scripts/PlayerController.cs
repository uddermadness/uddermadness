using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float walkSpeed = 2;
	public float runSpeed = 6;
	public float gravity = -12;
	public float jumpHeight = 1;
	[Range(0,1)]
	public float airControlPercent;

	public float turnSmoothTime = 0.2f;
	float turnSmoothVelocity;

	public float speedSmoothTime = 0.1f;
	float speedSmoothVelocity;
	float currentSpeed;
	float velocityY;

	Animator animator;
	Transform cameraT;
	CharacterController controller;

	Coroutine idleBreak;

	// gathering components at start
	void Start () {
		
		animator = GetComponent<Animator> ();
		// setting the object which the camera has to follow in this case it's an empty object set in the middle of the cow
		cameraT = Camera.main.transform;
		controller = GetComponent<CharacterController> ();
	}

	void Update () {
		// input of direction to the character
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		Vector2 inputDir = input.normalized;
		bool running = true;// Input.GetKey (KeyCode.LeftShift);
		// starting of idle animation
		if (idleBreak == null)
		{
			idleBreak = StartCoroutine(IdleBreak());
		}

		Move (inputDir, running);
		// stopping the secondary idle animation on jump
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (idleBreak != null)
			{
				StopCoroutine(idleBreak);
				idleBreak = null;
			}
			Jump ();
		}

		// animator
		// float animationSpeedPercent = ((running) ? currentSpeed / runSpeed : currentSpeed / walkSpeed * .5f);
		// animator.SetFloat ("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);

		if (animator.GetBool("Jumping") && controller.isGrounded)
			animator.SetTrigger("Land");

		animator.SetBool("Jumping", !controller.isGrounded);

	}

	void Move(Vector2 inputDir, bool running) {
		// if (inputDir != Vector2.zero) {
		// 	float targetRotation = Mathf.Atan2 (inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
		// 	transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(turnSmoothTime));
		// }

		// turning the character according to where the camera is facing	
		transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
		Vector3 inputDir3D = new Vector3(inputDir.x, 0f, inputDir.y);

		// smoothing of rotation and acceleration of character.
		float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
		currentSpeed = Mathf.SmoothDamp (currentSpeed, targetSpeed, ref speedSmoothVelocity, GetModifiedSmoothTime(speedSmoothTime));

		// setting of faux gravity on player
		velocityY += Time.deltaTime * gravity;
		Vector3 velocity = transform.TransformDirection(inputDir3D) * currentSpeed + Vector3.up * velocityY;

		controller.Move (velocity * Time.deltaTime);
		currentSpeed = new Vector2 (controller.velocity.x, controller.velocity.z).magnitude;

		// when the character is ground the y velocity is set to 0
		if (controller.isGrounded) {
			velocityY = 0;
		}

		// creating raycast to shoot below the character to check if it is sitting on a platform
		// if so the player becomes the child of the object
		// platforms must be set on the ground layer
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1f))
        {
			if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Ground"))
			{
				transform.SetParent(hit.transform);
			}
			else
			{
				transform.SetParent(null);
			}
        }
		// animation triggers
		animator.SetBool("Moving", inputDir.magnitude > Mathf.Epsilon);
		animator.SetFloat("FwdBack", inputDir.normalized.y == 0 ? 1f : inputDir.normalized.y);
		animator.SetFloat("Strafing", (1f + inputDir.normalized.x) * 0.5f);

		// stopping the secondary idle animation as velocity is increased.
		if (controller.velocity != Vector3.zero && idleBreak != null)
		{
			StopCoroutine(idleBreak);
			idleBreak = null;
		}
	}

	

	
	void Jump() {
		// checking if character is grounded if so apply force on cow upwards to jump
		if (controller.isGrounded) {
			float jumpVelocity = Mathf.Sqrt (-2 * gravity * jumpHeight);
			velocityY = jumpVelocity;
		}
	}

	// adding smoothing to character rotation
	float GetModifiedSmoothTime(float smoothTime) {
		if (controller.isGrounded) {
			return smoothTime;
		}

		if (airControlPercent == 0) {
			return float.MaxValue;
		}
		return smoothTime / airControlPercent;
	}

	// setting timer for extra idle animation
	IEnumerator IdleBreak()
	{
		while (true)
		{	
			// 15 secs timer set before secondary idle animation is triggered
			yield return new WaitForSeconds(15f);
			animator.SetTrigger("Idle Break");
		}
	}

	// attempt to address doors with scriptable object to create key collection
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
		{
			other.gameObject.GetComponent<Door>().Open();
		}
	}
}
