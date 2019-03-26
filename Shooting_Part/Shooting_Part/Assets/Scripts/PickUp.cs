using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

	public Shooting shooting;

	void OnTriggerEnter(Collider target)
	{
		if (target.tag == "PickUp")
		{
			PickupType type = target.GetComponent<PickupType>();
			shooting.AddBullets(type.type.ammoName);
		}

		if (target.gameObject.layer == LayerMask.NameToLayer("PickUp"))
		{
			Destroy(target.gameObject);
		}
	}
}

