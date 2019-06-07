using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Game/Inventory/Item Data", fileName = "New ItemData")]

//setting the pick up items needed to be in the inventory
public class ItemData : ScriptableObject
{
	public string itemName;

	public string itemDescription;

	public int ammoCount;

	public Sprite icon;
	
}
