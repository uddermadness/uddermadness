using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
	public void Clicky(ItemData data)
	{
		Inventory.main.Pickup(data);
	}
}
