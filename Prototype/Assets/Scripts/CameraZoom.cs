using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraZoom : MonoBehaviour {

	public Camera m_OrthographicCamera;
	float maxZoom = 0.42f;
	float minZoom = 1f;

	float curZoom = 0.42f;

	public Button m_PlusButton, m_MinusButton;

	void Start()
	{
		m_PlusButton = gameObject.GetComponent<Button>();
		m_MinusButton = gameObject.GetComponent<Button>();

	}

	public void ZoomIn()
	{
		curZoom = Mathf.Clamp(curZoom + 1f * Time.deltaTime, maxZoom, minZoom);
	}

	public void ZoomOut()
	{
		curZoom = Mathf.Clamp(curZoom - 1f * Time.deltaTime, maxZoom, minZoom);
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


