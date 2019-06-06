using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraZoom : MonoBehaviour {

	public Camera m_OrthographicCamera;
	float maxZoom = 50f;
	float minZoom = 10f;

	float curZoom = 50f;

	public void ZoomIn()
	{
		if(curZoom == minZoom)
		{
			curZoom = Mathf.Clamp(curZoom + 25f * Time.deltaTime, maxZoom, minZoom);
		}
	}

	public void ZoomOut()
	{
		if(curZoom == maxZoom)
		{
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

		m_OrthographicCamera.orthographicSize = curZoom;
	} 
}


