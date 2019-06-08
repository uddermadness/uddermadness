using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

	public Shooting shooting;

	public Inventory inventory;

	void OnTriggerEnter(Collider target)
	{
		//if pickup is triggered add bullets to the inventory
		if (target.tag == "PickUp")
		{
			//setting pickup type
			PickupType type = target.GetComponent<PickupType>();
			shooting?.AddBullets(type.type.ammoName);
			//adding pickup to the inventory
			inventory.Pickup(type.item);
		}
		//destroying pickup object as player collides with pick up layer
		if (target.gameObject.layer == LayerMask.NameToLayer("PickUp"))
		{
			Destroy(target.gameObject);
		}
	}
}

