using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using SimpleJSON;

public class CameraZoom : MonoBehaviour
{
	private Transform target;
	private Vector3 initialPosition;
	private bool isZooming = false;
	private int whichOrganZoomed = 0;
    public AudioSource battement;
	private HeartScript heart;
    //private GameObject button;
	private Gastrite gastrite;
	private HeartIllness2 trachea;
	private StomachScriptIllness2 stomach;

	public void SetHeart(HeartScript value)
	{
		heart = value;
	}

	public void SetStomach(StomachScriptIllness2 value)
	{
		stomach = value;
	}

	public void SetTrachea(HeartIllness2 value)
	{
		trachea = value;
	}

	public void SetGastrite(Gastrite value)
	{
		gastrite = value;
	}

	private void Start()
	{
		initialPosition = transform.position;
		
    }

	//void Awake(){
	//	GameObject temp = GameObject.FindGameObjectWithTag("Gastrite");
	//	if(gastrite != null) 
	//		gastrite = temp.GetComponent<Gastrite>();
	//	button = GameObject.FindGameObjectWithTag("button");
	//	if (button != null)
	//		button.SetActive(false);
	//	Debug.Log("Bouton : " + button);
	//}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			var ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 1000))
			{
				if (hit.collider.tag == "Heart")
				{
                    Debug.Log("Heart");
					isZooming = true;
					heart.isZoomed = true;
					heart.DisplayDisease();
					whichOrganZoomed = 1;
                    target = GameObject.Find("ZoomPointOrgan1").transform;
                }
				else if (hit.collider.tag == "Stomach" && whichOrganZoomed != 2)
                {
                    Debug.Log("Stomach");
                    isZooming = true;
					whichOrganZoomed = 2;
					stomach.gameObject.SetActive(true);
					target = GameObject.Find("ZoomPointOrgan2").transform;
				}
				else if (hit.collider.tag == "body" && whichOrganZoomed != 0)
                {
                    Debug.Log("body");
                    isZooming = false;
					if (heart != null)
						heart.HideDisease();
					if(stomach != null)
						stomach.gameObject.SetActive(false);
                    whichOrganZoomed = 0;
					if(trachea != null)
						GameObject.Find("CanvasSeringue").GetComponent<Canvas>().enabled = false;
					if (gastrite)
						gastrite.HideDisease();
                }
                else if(hit.collider.tag == "sheet" && whichOrganZoomed != 3)
                {
                    Debug.Log("sheet");
                    isZooming = true;
                    whichOrganZoomed = 3;
                    target = GameObject.Find("ZoomPointSheet").transform;
                }else if (hit.collider.tag == "trachea")
                {
                    Debug.Log("Trachea");
                    isZooming = true;
                    whichOrganZoomed = 4;
                    target = GameObject.Find("ZoomPointOrgan3").transform;
                    GameObject.Find("CanvasSeringue").GetComponent<Canvas>().enabled = true;
                }else if (hit.collider.tag == "Intestine")
				{
					Debug.Log("Intestine");
					isZooming = true;
					whichOrganZoomed = 5;
					target = GameObject.Find("ZoomPointOrgan4").transform;
					gastrite.DisplayDisease ();

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
			if(heart != null)
				heart.isZoomed = false;
			battement.Stop();
			transform.position = Vector3.Lerp(transform.position, initialPosition, 0.2f);
			//GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
		}
	}
	

}
