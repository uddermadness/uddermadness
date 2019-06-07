using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Inventory/Collection")]
public class Inventory : ScriptableObject
{
	//new list for items
	public List<InventoryItem> items = new List<InventoryItem>();

    public void Pickup(ItemData item, int count)
	{
		//for each inventory item
		foreach (InventoryItem i in items)
		{
			//if the item is equal to the button clicked
			if (i.item == item)
			{
				//then count
				i.count += count;
				return;
			}
		}

		// then will add the item in the inventory
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
