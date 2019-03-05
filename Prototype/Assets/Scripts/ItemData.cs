using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Item Data", fileName = "New ItemData")]

public class ItemData : ScriptableObject
{
	public string itemName;

	public string itemDescription;

	public Sprite icon;
	
}
