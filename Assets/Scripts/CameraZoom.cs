using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
	private int zoom =10;
	private int normal = 60;
	private Transform target;
	private Vector3 initialPosition;
	private float smooth = 5;
	private float smoothPos = 0.1f;
	private bool isZooming = false;
	private bool isZoomed = false;
	private int whichOrganZoomed = 0;
    public AudioSource battement;
    

    private void Start()
	{
		initialPosition = transform.position;

    }

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			var ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 1000))
			{
				if (hit.collider.tag == "Organ1")
				{
                    Debug.Log("Organ1");
					isZooming = true;
					whichOrganZoomed = 1;
                    target = GameObject.Find("ZoomPointOrgan1").transform;
				}
				else
				{
					if (hit.collider.tag == "Organ2" && whichOrganZoomed != 2)
                    {
                        Debug.Log("Organ2");
                        isZooming = true;
						whichOrganZoomed = 2;
						target = GameObject.Find("ZoomPointOrgan2").transform;
					}
					else
					{
						if (hit.collider.tag != "Organ1" && hit.collider.tag != "sheet" && whichOrganZoomed != 0)
                        {
                            Debug.Log("body");
                            isZooming = false;
							whichOrganZoomed = 0;
                        }else
                        {
                            Debug.Log("test sheet");
                            if(hit.collider.tag == "sheet" && whichOrganZoomed != 3)
                            {
                                Debug.Log("sheet");
                                isZooming = true;
                                whichOrganZoomed = 3;
                                target = GameObject.Find("ZoomPointSheet").transform;
                            }
                        }
					}
				}

			}

			
		}
		if (isZooming && whichOrganZoomed != 0)
		{
            battement.Play();
            transform.position = Vector3.Lerp(transform.position, target.position, 0.2f);
            //GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
        }
		else
		{
            battement.Stop();
			transform.position = Vector3.Lerp(transform.position, initialPosition, 0.2f);
			//GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
		}
	}

	public bool V3Equal(Vector3 a, Vector3 b)
	{
		return Vector3.SqrMagnitude(a - b) < 0.1;
	}

}
