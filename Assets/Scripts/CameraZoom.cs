using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
	private int zoom = 10;
	private int normal = 60;
	public Transform target;
	private Vector3 initialPosition;
	private float smooth = 5;
	private float smoothPos = 0.1f;
	private bool isZooming = false;

	private void Start()
	{
		initialPosition = GetComponent<Camera>().transform.position;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			var ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 100))
			{
				if (hit.collider.tag == "Organ2" && !V3Equal(GetComponent<Camera>().transform.position, target.position))
				{
					isZooming = true;
				}
				else if(V3Equal(GetComponent<Camera>().transform.position, target.position))
				{
					isZooming = false;
				}
			}

			
		}
		if (isZooming)
		{
			transform.position = Vector3.Lerp(GetComponent<Camera>().transform.position, target.position, 0.2f);
			//GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
		}
		else
		{
			GetComponent<Camera>().transform.position = Vector3.Lerp(GetComponent<Camera>().transform.position, initialPosition, 0.2f);
			//GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
		}
	}

	public bool V3Equal(Vector3 a, Vector3 b)
	{
		return Vector3.SqrMagnitude(a - b) < 0.1;
	}

}
