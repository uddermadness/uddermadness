﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
		//amount of ammo collected each time
		Pickup(item, 250);
	}

	public bool Has(ItemData item)
	{
		return items.Where(inv => inv.item == item).Count() > 0;
	}
}
