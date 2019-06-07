using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		//when the user clicks on the left arrow the player moves forward
		if (Input.GetKey(KeyCode.LeftArrow)) {
     		transform.Translate(Vector3.forward * Time.deltaTime);
		}
	}
}
