using UnityEngine;

[System.Serializable]
public class InventoryItem
{
	[SerializeField]
	public int count;

	[SerializeField]
	public ItemData item;

	public InventoryItem(ItemData item, int count)
	{
		this.item = item;
		this.count = count;
	}
}
