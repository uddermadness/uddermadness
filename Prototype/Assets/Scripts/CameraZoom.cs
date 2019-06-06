using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraZoom : MonoBehaviour {

	public Camera m_OrthographicCamera;
	float maxZoom = 5.31f;
	float minZoom = 1f;

	float curZoom = 5.31f;

	public void ZoomIn()
	{
		curZoom = Mathf.Clamp(curZoom + 25f * Time.deltaTime, maxZoom, minZoom);
	}

	public void ZoomOut()
	{
		curZoom = Mathf.Clamp(curZoom - 25f * Time.deltaTime, maxZoom, minZoom);
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


