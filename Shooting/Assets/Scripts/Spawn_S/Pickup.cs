using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	public Spawner movement;

	void OnTriggerEnter(Collider target)
	{
		if (target.tag == "Red")
		{
			movement.enabled = false;
		}

		if (target.gameObject.layer == LayerMask.NameToLayer("Pickups"))
		{
			Destroy(target.gameObject);
		}
	}
}

