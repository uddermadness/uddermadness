using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
	public Inventory inventory;

	//onclick show the Item picked in the inventory
	public void Clicky(ItemData data)
	{
		inventory.Pickup(data);
	}
}
