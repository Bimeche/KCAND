using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartIllness2 : MonoBehaviour {

    public Image fill;
    public Canvas seringue;
    private Camera sceneCamera;
    private bool fillingUp;
    private bool fillingDown;
    public Material buttonNonAccessible;
    public Material buttonAccessible;
    public Material buttonPressed;
    private FillSheet sheet;
    private bool success;
    private AudioSource achievement;
    private int dose;

    void Start()
    {
       
        achievement = GameObject.Find("achievement").GetComponent<AudioSource>();
        seringue.enabled = false;
        fillingUp = false;
        fillingDown = false;
        success = false;
       
    }

	private void Awake()
	{
		sheet = FindObjectOfType<FillSheet>();
		sceneCamera = FindObjectOfType<Camera>();
        dose = sheet.getDose();
	}

	// Update is called once per frame
	void Update()
    {
        var ray = sceneCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 1000))
            {
				Debug.Log(hit.point);
				Debug.Log(GameObject.FindGameObjectWithTag("seringue").transform.position);
                if (hit.collider.tag == "plusbutton")
                {
                    Debug.Log("seringue");
                    fillingUp = true;

				}
				else if (hit.collider.tag == "minusbutton")
				{
					fillingDown = true;
				}
				else if(hit.collider.tag == "inject")
                {
                    //verifier si bonne dose
                    Debug.Log("verify");
                    switch (dose)
                    {
                        case 6:
                            if (fill.fillAmount >= 0.226 && fill.fillAmount <= 0.236) success = true;
                            break;
                        case 9:
                            if (fill.fillAmount >= 0.256 && fill.fillAmount <= 0.266) success = true;
                            break;
                        case 11:
                            if (fill.fillAmount >= 0.275 && fill.fillAmount <= 0.285) success = true;
                            break;
                        case 14:
                            if (fill.fillAmount >= 0.312 && fill.fillAmount <= 0.322) success = true;
                            break;
                        case 16:
                            if (fill.fillAmount >= 0.330 && fill.fillAmount <= 0.340) success = true;
                            break;
                        case 17:
                            if (fill.fillAmount >= 0.342 && fill.fillAmount <= 0.352) success = true;
                            break;
                        case 19:
                            if (fill.fillAmount >= 0.360 && fill.fillAmount <= 0.370) success = true;
                            break;
                        case 20:
                            if (fill.fillAmount >= 0.372 && fill.fillAmount <= 0.382) success = true;
                            break;
                        case 21:
                            if (fill.fillAmount >= 0.383 && fill.fillAmount <= 0.393) success = true;
                            break;
                        case 22:
                            if (fill.fillAmount >= 0.394 && fill.fillAmount <= 0.404) success = true;
                            break;
                        case 24:
                            if (fill.fillAmount >= 0.412 && fill.fillAmount <= 0.422) success = true;
                            break;
                        case 25:
                            if (fill.fillAmount >= 0.421 && fill.fillAmount <= 0.431) success = true;
                            break;
                        case 26:
                            if (fill.fillAmount >= 0.433 && fill.fillAmount <= 0.443) success = true;
                            break;
                        case 27:
                            if (fill.fillAmount >= 0.445 && fill.fillAmount <= 0.455) success = true;
                            break;
                        case 29:
                            if (fill.fillAmount >= 0.463 && fill.fillAmount <= 0.473) success = true;
                            break;
                        case 30:
                            if (fill.fillAmount >= 0.475 && fill.fillAmount <= 0.485) success = true;
                            break;
                        case 32:
                            if (fill.fillAmount >= 0.493 && fill.fillAmount <= 0.503) success = true;
                            break;
                        case 34:
                            if (fill.fillAmount >= 0.515 && fill.fillAmount <= 0.525) success = true;
                            break;
                        case 35:
                            if (fill.fillAmount >= 0.527 && fill.fillAmount <= 0.537) success = true;
                            break;
                        case 37:
                            if (fill.fillAmount >= 0.550 && fill.fillAmount <= 0.560) success = true;
                            break;
                        case 39:
                            if (fill.fillAmount >= 0.568 && fill.fillAmount <= 0.578) success = true;
                            break;
                        case 40:
                            if (fill.fillAmount >= 0.580 && fill.fillAmount <= 0.590) success = true;
                            break;
                        case 42:
                            if (fill.fillAmount >= 0.598 && fill.fillAmount <= 0.608) success = true;
                            break;
                    }
                    GameObject.Find("InjectButton").GetComponent<Renderer>().material = buttonPressed;
                    if (success)
                    {
                        achievement.Play();
                        Debug.Log("Done");
                        GameObject.Find("Heart").SetActive(false);
                        GameObject.Find("InjectButton").SetActive(false);
                        seringue.enabled = false;
                    }else
                    {
                        GameObject.Find("InjectButton").GetComponent<Renderer>().material = buttonNonAccessible;
						sceneCamera.GetComponent<strikeScript> ().nbstrike--;
						if (sceneCamera.GetComponent<strikeScript> ().nbstrike == 0){
							NavigationBetweenScenes end = FindObjectOfType<NavigationBetweenScenes> ();
							end.SetLose ();
							end.GameOver ();
						}
                    }
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            fillingUp = false;
			fillingDown = false;
        }

        if (fillingUp)
        {
            if(fill.fillAmount < 0.688)
                fill.fillAmount += 0.0005f;
        }
        if (fillingDown)
        {
            if(fill.fillAmount > 0.17)
            {
                fill.fillAmount -= 0.0005f;
            }else
            {
                GameObject.Find("InjectButton").GetComponent<Renderer>().material = buttonNonAccessible;
            }
        }


   }
}
