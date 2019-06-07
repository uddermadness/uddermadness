using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {

	//setting a variable for the player
	public Transform player;

	void LateUpdate()
	{
		// the player can move up 
		Vector3 newPosition = player.position;
		newPosition.y = transform.position.y;
		transform.position = newPosition;
	}
}
