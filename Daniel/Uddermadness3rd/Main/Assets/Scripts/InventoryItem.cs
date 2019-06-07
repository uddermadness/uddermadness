using UnityEngine;

[System.Serializable]
public class InventoryItem
{
	[SerializeField]
	public int count;
	//setting the variable to serializable field so that it can be set from the inspector

	[SerializeField]
	//getting the variable from the Item data
	public ItemData item;

	public InventoryItem(ItemData item, int count)
	{
		//setting the inventory item
		this.item = item;
		this.count = count;
	}
}
