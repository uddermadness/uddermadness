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

	void Start () {
		animator = GetComponent<Animator> ();
		cameraT = Camera.main.transform;
		controller = GetComponent<CharacterController> ();
	}

	void Update () {
		// input
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		Vector2 inputDir = input.normalized;
		bool running = true;// Input.GetKey (KeyCode.LeftShift);

		if (idleBreak == null)
		{
			idleBreak = StartCoroutine(IdleBreak());
		}

		Move (inputDir, running);

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
			
		transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
		Vector3 inputDir3D = new Vector3(inputDir.x, 0f, inputDir.y);

		float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
		currentSpeed = Mathf.SmoothDamp (currentSpeed, targetSpeed, ref speedSmoothVelocity, GetModifiedSmoothTime(speedSmoothTime));

		velocityY += Time.deltaTime * gravity;
		Vector3 velocity = transform.TransformDirection(inputDir3D) * currentSpeed + Vector3.up * velocityY;

		controller.Move (velocity * Time.deltaTime);
		currentSpeed = new Vector2 (controller.velocity.x, controller.velocity.z).magnitude;

		if (controller.isGrounded) {
			velocityY = 0;
		}

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

		animator.SetBool("Moving", inputDir.magnitude > Mathf.Epsilon);
		animator.SetFloat("FwdBack", inputDir.normalized.y == 0 ? 1f : inputDir.normalized.y);
		animator.SetFloat("Strafing", (1f + inputDir.normalized.x) * 0.5f);

		if (controller.velocity != Vector3.zero && idleBreak != null)
		{
			StopCoroutine(idleBreak);
			idleBreak = null;
		}
	}

	


	void Jump() {
		if (controller.isGrounded) {
			float jumpVelocity = Mathf.Sqrt (-2 * gravity * jumpHeight);
			velocityY = jumpVelocity;
		}
	}

	float GetModifiedSmoothTime(float smoothTime) {
		if (controller.isGrounded) {
			return smoothTime;
		}

		if (airControlPercent == 0) {
			return float.MaxValue;
		}
		return smoothTime / airControlPercent;
	}

	IEnumerator IdleBreak()
	{
		while (true)
		{
			yield return new WaitForSeconds(15f);
			animator.SetTrigger("Idle Break");
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
		{
			other.gameObject.GetComponent<Door>().Open();
		}
	}
}
