using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

	public Shooting shooting;

	public Inventory inventory;

	void OnTriggerEnter(Collider target)
	{
		if (target.tag == "PickUp")
		{
			PickupType type = target.GetComponent<PickupType>();
			shooting?.AddBullets(type.type.ammoName);

			inventory.Pickup(type.item);
		}

		if (target.gameObject.layer == LayerMask.NameToLayer("PickUp"))
		{
			Destroy(target.gameObject);
		}
	}
}

