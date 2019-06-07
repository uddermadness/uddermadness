using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraZoom : MonoBehaviour {

	//adding a variable for the camera
	public Camera m_OrthographicCamera;

	//setting the max and min zoom for the map 
	float maxZoom = 50f;
	float minZoom = 10f;

	//setting the current zoom
	float curZoom = 50f;

	public void ZoomIn()
	{
		//if the current zoom matches the minZoom, zoom in
		if(curZoom == minZoom)
		{
			//on zoom in, the image will zoom in by 25 
			curZoom = Mathf.Clamp(curZoom + 25f * Time.deltaTime, maxZoom, minZoom);
		}
	}

	public void ZoomOut()
	{
		//if the current zoom matches the maxZoom, zoom out
		if(curZoom == maxZoom)
		{
			//on zoom out, the image will zoom out by 25 
			curZoom = Mathf.Clamp(curZoom - 25f * Time.deltaTime, maxZoom, minZoom);
		}
	}
	

	void Update(){
		/* if (Input.GetKey(KeyCode.UpArrow))
		{
			curZoom = Mathf.Clamp(curZoom + 1f * Time.deltaTime, maxZoom, minZoom);
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			curZoom = Mathf.Clamp(curZoom - 1f * Time.deltaTime, maxZoom, minZoom);
		} */

		//setting the orthographic camera size to the current zoom
		m_OrthographicCamera.orthographicSize = curZoom;
	} 
}


