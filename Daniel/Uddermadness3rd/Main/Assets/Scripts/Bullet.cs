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
		Vector3 shootDir = Random.insideUnitSphere * 0.1f;
		shootDir.z = 1f;

		rb.AddForce(transform.TransformDirection(shootDir) * force, ForceMode.Impulse);
		Destroy(gameObject, 2f);
	}
}
