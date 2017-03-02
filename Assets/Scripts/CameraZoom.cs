using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

	public float zoomSensitivity = 15.0f;
	public float zoomSpeed = 5.0f;
	public float zoomMin = 5.0f;
	public float zoomMax = 80.0f;

	private float zoom;


	void Start()
	{
		zoom = GetComponent<Camera>().fieldOfView;
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
		}
		zoom -= Input.GetAxis("Vertical") * zoomSensitivity;
		zoom = Mathf.Clamp(zoom, zoomMin, zoomMax);
	}

	void LateUpdate()
	{
		GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * zoomSpeed);
	}
}
