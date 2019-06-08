using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		//sets cursor to be visible
		Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//moves the cursor to the position of mouse
		this.transform.position = Input.mousePosition;
	}
}
