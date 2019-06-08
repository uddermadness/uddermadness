using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {

	Rigidbody rb;

	public float force = 50f;

	private void Awake() {
		//finding rigid component
		rb = GetComponent<Rigidbody>();
	}

	// Use this for initialization
	void Start () {
		//shooting direction 
		Vector3 shootDir = Random.insideUnitSphere * 0.1f;
		shootDir.z = 1f;
		//adding force to the bullet and destorying it after 2 seconds
		rb.AddForce(transform.TransformDirection(shootDir) * force, ForceMode.Impulse);
		Destroy(gameObject, 2f);
	}
}
