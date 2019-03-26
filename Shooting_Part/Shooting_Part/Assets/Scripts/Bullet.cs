using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {

	Rigidbody rb;

	public float force = 50f;

	private void Awake() {
		rb = GetComponent<Rigidbody>();
	}

	// Use this for initialization
	void Start () {
		rb.AddForce(transform.TransformDirection(Vector3.forward) * force, ForceMode.Impulse);
		Destroy(gameObject, 0.5f);
	}
}
