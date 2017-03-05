using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
	private int zoom = 10;
	private int normal = 60;
	private Transform target;
	private Vector3 initialPosition;
	private float smooth = 5;
	private float smoothPos = 0.1f;
	private bool isZooming = false;
	private bool isZoomed = false;
	private int whichOrganZoomed = 0;

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
				if (hit.collider.tag == "Organ1" && whichOrganZoomed!=1)
				{
					isZooming = true;
					whichOrganZoomed = 1;
					target = GameObject.Find("ZoomPointOrgan1").transform;
				}
				else
				{
					if (hit.collider.tag == "Organ2" && whichOrganZoomed != 1)
					{
						isZooming = true;
						whichOrganZoomed = 2;
						target = GameObject.Find("ZoomPointOrgan2").transform;
					}
					else
					{
						if (hit.collider.tag == "body" && whichOrganZoomed != 0)
						{
							isZooming = false;
							whichOrganZoomed = 0;
						}
					}
				}

			}

			
		}
		if (isZooming && whichOrganZoomed != 0)
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
