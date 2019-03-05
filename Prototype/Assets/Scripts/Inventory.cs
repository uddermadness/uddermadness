using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public static Inventory main { get; private set; }

	public List<InventoryItem> items = new List<InventoryItem>();

	public Button buttonTemplate;

	public Transform itemsParent;

	private void Awake()
	{
		if (main == null)
		{
			main = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			DestroyImmediate(this);
		}
	}

	private void Start()
	{
		buttonTemplate.gameObject.SetActive(false);
	}

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
		Button b = Instantiate<Button>(buttonTemplate, itemsParent);
		b.GetComponent<Image>().sprite = item.icon;
		b.gameObject.SetActive(true);
	}

	public void Pickup(ItemData item)
	{
		Pickup(item, 1);
	}
}
