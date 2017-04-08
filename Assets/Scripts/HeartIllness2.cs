using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartIllness2 : MonoBehaviour {

    public Image fill;
    public Canvas seringue;
    public Camera sceneCamera;
    private bool fillingUp;
    private bool fillingDown;
    public Material buttonNonAccessible;
    public Material buttonAccessible;
    public Material buttonPressed;

    void Start()
    {
        seringue.enabled = false;
        fillingUp = false;
        fillingDown = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (fill.fillAmount > 0.17)
        {
            GameObject.Find("InjectButton").GetComponent<Renderer>().material = buttonAccessible;
        }
        var ray = sceneCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.tag == "seringue")
                {
                    fillingUp = true;

                }else if(hit.collider.tag == "inject")
                {
                    //verifier si bonne dose
                    Debug.Log("verify");
                    GameObject.Find("InjectButton").GetComponent<Renderer>().material = buttonPressed;
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.tag == "seringue")
                {
                    fillingDown = true;
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            fillingUp = false;
        }
        else if (Input.GetMouseButtonUp(1))
        {
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
