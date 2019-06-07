using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

	//getting the variables from the Inventory, InventoryItemUI scripts
	public Inventory inventory;

	public InventoryItemUI buttonTemplate;

	public Transform itemsParent;

	private void Start()
	{
		//setting a button template to generate items onplay
		buttonTemplate.gameObject.SetActive(false);
		GenerateItems();
		Debug.Log("HELLO");
	}

	private void GenerateItems()
	{
		//for eaach inventory Item
		foreach (InventoryItem inventoryItem in inventory.items)
		{
			//set the sprite and amount in text so that it generates
			InventoryItemUI b = Instantiate<InventoryItemUI>(buttonTemplate, itemsParent);
			b.image.sprite = inventoryItem.item.icon;
			b.amount.SetText(inventoryItem.count.ToString());
			b.gameObject.SetActive(true);
		}
	}
}
