using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
	public Inventory inventory;

	public void Clicky(ItemData data)
	{
		inventory.Pickup(data);
	}
}
