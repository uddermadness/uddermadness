using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

	public Inventory inventory;

	public InventoryItemUI buttonTemplate;

	public Transform itemsParent;

	private void Start()
	{
		buttonTemplate.gameObject.SetActive(false);
		GenerateItems();
		Debug.Log("HELLO");
	}

	private void GenerateItems()
	{
		foreach (InventoryItem inventoryItem in inventory.items)
		{
			InventoryItemUI b = Instantiate<InventoryItemUI>(buttonTemplate, itemsParent);
			b.image.sprite = inventoryItem.item.icon;
			b.amount.SetText(inventoryItem.count.ToString());
			b.gameObject.SetActive(true);
		}
	}
}
