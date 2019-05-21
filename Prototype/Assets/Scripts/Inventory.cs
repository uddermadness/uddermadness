using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Inventory/Collection")]
public class Inventory : ScriptableObject
{
	public List<InventoryItem> items = new List<InventoryItem>();

    public void Pickup(ItemData item, int count)
	{
		foreach (InventoryItem i in items)
		{
			if (i.item == item)
			{
				i.count += count;
				return;
			}
		}

		items.Add(new InventoryItem(item, count));
	}

	public void Pickup(ItemData item)
	{
		Pickup(item, 1);
	}
}
