using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StomachScriptIllness2 : MonoBehaviour {
    
    public Material red_material;
    public Material red_material_pressed;
    public Material yellow_material;
    public Material yellow_material_pressed;
    public TextMesh word;
    public Camera sceneCamera;
    public Text timer;
    public FillSheet sheet;
    private int texture;
    private int random_word;
    private bool good_timer = false;
    private Renderer rend;
    private float chrono;
    private int nb;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        texture = Random.Range(0, 2);
        if(texture == 0)
        {
            rend.material = red_material;
        }else
        {
            rend.material = yellow_material;
        }
        random_word = Random.Range(0, 3);
        switch (random_word)
        {
            case 0:
                word.text = "café";
                break;
            case 1:
                word.text = "alcool";
                if(texture == 0)
                {
                    if (Random.Range(0, 2) == 0)
                    {
                        sheet.FillDocument(sheet.GetComponent<FillSheet>().ligne1.text, sheet.GetComponent<FillSheet>().ligne2.text, sheet.GetComponent<FillSheet>().ligne3.text, "Boit beaucoup d'alcool.", sheet.GetComponent<FillSheet>().ligne5.text);
                    }
                    else
                    {
                        nb = Random.Range(2, 9);
                        sheet.FillDocument(sheet.GetComponent<FillSheet>().ligne1.text, sheet.GetComponent<FillSheet>().ligne2.text, sheet.GetComponent<FillSheet>().ligne3.text, "A perdu "+ nb +" fois connaissances.", sheet.GetComponent<FillSheet>().ligne5.text);
                    }
                }
                break;
            case 2:
                word.text = "tabac";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        var ray = sceneCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        switch (texture)
                 {
                     case 0:
                         switch (random_word)
                         {
                             case 0:    
                            if(Input.GetMouseButtonDown(0)) rend.material = red_material_pressed;
                            if (Input.GetMouseButtonUp(0))
                            {
                                rend.material = red_material;
                                if (Physics.Raycast(ray, out hit, 1000))
                                {
                                    if (hit.collider.name.Contains("button"))
                                    {
                                        if (GameObject.Find("Main Camera").GetComponent<strikeScript>().nbstrike >= 2)
                                        {
                                            for (int i = 0; i < timer.text.Length; i++)
                                            {
                                                if (timer.text.Substring(i, 1) == "2") good_timer = true;
                                            }
                                        }
                                        else
                                        {
                                            for (int i = 0; i < timer.text.Length; i++)
                                            {
                                                if (timer.text.Substring(i, 1) == GameObject.Find("sheet").GetComponent<FillSheet>().ligne1.text.Substring(7)) good_timer = true;
                                            }
                                        }
                                    if (good_timer)
                                    {
                                        Debug.Log("Done");
                                        GameObject.Find("button").SetActive(false);
                                        GameObject.Find("SmallIntestine_Plane.004").SetActive(false);
                                    }
                                    else
                                    {
                                        if (GameObject.Find("Main Camera").GetComponent<strikeScript>().nbstrike > 0)
                                            GameObject.Find("Main Camera").GetComponent<strikeScript>().nbstrike--;
                                        else Debug.Log("You lose");
                                    }

                                }
                                 }
                              }
                            break;
                        case 1:
                        if (Input.GetMouseButtonDown(0))
                        {
                            chrono = Time.time;
                            rend.material = red_material_pressed;
                        }
                        if (Input.GetMouseButtonUp(0))
                        {
                            rend.material = red_material;
                            if (Physics.Raycast(ray, out hit, 1000))
                            {
                                if (hit.collider.name.Contains("button"))
                                {
                                    if (sheet.GetComponent<FillSheet>().ligne4.text == "Boit beaucoup d'alcool.")
                                    {
                                        if (Time.time-chrono <= 0.1f ){
                                            good_timer = true;
                                        }
                                    }
                                    else if(sheet.GetComponent<FillSheet>().ligne4.text == "A perdu " + nb +" fois connaissances.")
                                    {
                                        for (int i = 0; i < timer.text.Length; i++)
                                        {
                                            if (timer.text.Substring(i, 1) == nb.ToString()) good_timer = true;
                                        }
                                    }
                                    if (good_timer)
                                    {
                                        Debug.Log("Done");
                                        GameObject.Find("button").SetActive(false);
                                        GameObject.Find("SmallIntestine_Plane.004").SetActive(false);
                                    }
                                    else
                                    {
                                        if (GameObject.Find("Main Camera").GetComponent<strikeScript>().nbstrike > 0)
                                            GameObject.Find("Main Camera").GetComponent<strikeScript>().nbstrike--;
                                        else Debug.Log("You lose");
                                    }

                                }
                            }
                        }
                        break;
                        case 2:
                        if (Input.GetMouseButtonDown(0))
                        {
                            chrono = Time.time;
                            rend.material = red_material_pressed;
                        }
                        if (Input.GetMouseButtonUp(0))
                        {
                            rend.material = red_material;
                            if (Physics.Raycast(ray, out hit, 1000))
                            {
                                if (hit.collider.name.Contains("button"))
                                {
                                    if (int.Parse(GameObject.Find("sheet").GetComponent<FillSheet>().ligne1.text.Substring(6)) < 25)
                                    {
                                        if (Time.time - chrono <= 0.1f)
                                        {
                                            good_timer = true;
                                        }
                                    }
                                    else
                                    {
                                        for (int i = 0; i < timer.text.Length; i++)
                                        {
                                            if (timer.text.Substring(i, 1) == "1") good_timer = true;
                                        }
                                    }
                                    if (good_timer)
                                    {
                                        Debug.Log("Done");
                                        GameObject.Find("button").SetActive(false);
                                        GameObject.Find("SmallIntestine_Plane.004").SetActive(false);
                                    }
                                    else
                                    {
                                        if (GameObject.Find("Main Camera").GetComponent<strikeScript>().nbstrike > 0)
                                            GameObject.Find("Main Camera").GetComponent<strikeScript>().nbstrike--;
                                        else Debug.Log("You lose");
                                    }

                                }
                            }
                        }
                        break; 
                    }
                    break;
                case 1:
                    switch (random_word)
                    {
                        case 0:
                        if (Input.GetMouseButtonDown(0))
                        {
                            chrono = Time.time;
                            rend.material = yellow_material_pressed;
                        }
                        if (Input.GetMouseButtonUp(0))
                        {
                            rend.material = yellow_material;
                            if (Physics.Raycast(ray, out hit, 1000))
                            {
                                if (hit.collider.name.Contains("button"))
                                {
                                    if (GameObject.Find("Heart") != null)
                                    {
                                        for (int i = 0; i < timer.text.Length; i++)
                                        {
                                            if (timer.text.Substring(i, 1) == "5") good_timer = true;
                                        }
                                        
                                    }
                                    else
                                    {
                                        if (Time.time - chrono <= 0.1f)
                                        {
                                            good_timer = true;
                                        }
                                    }
                                    if (good_timer)
                                    {
                                        Debug.Log("Done");
                                        GameObject.Find("button").SetActive(false);
                                        GameObject.Find("SmallIntestine_Plane.004").SetActive(false);
                                    }
                                    else
                                    {
                                        if (GameObject.Find("Main Camera").GetComponent<strikeScript>().nbstrike > 0)
                                            GameObject.Find("Main Camera").GetComponent<strikeScript>().nbstrike--;
                                        else Debug.Log("You lose");
                                    }

                                }
                            }
                        }
                        break;
                        case 1:
                        if (Input.GetMouseButtonDown(0))
                        {
                            rend.material = yellow_material_pressed;
                        }
                        if (Input.GetMouseButtonUp(0))
                        {
                            rend.material = yellow_material;
                            if (Physics.Raycast(ray, out hit, 1000))
                            {
                                if (hit.collider.name.Contains("button"))
                                {
                                    if (int.Parse(GameObject.Find("sheet").GetComponent<FillSheet>().ligne1.text.Substring(6)) < 50)
                                    {
                                        for (int i = 0; i < timer.text.Length; i++)
                                        {
                                            if (timer.text.Substring(i, 1) == GameObject.Find("sheet").GetComponent<FillSheet>().ligne1.text.Substring(7)) good_timer = true;
                                        }

                                    }
                                    else
                                    {
                                        for (int i = 0; i < timer.text.Length; i++)
                                        {
                                            if (timer.text.Substring(i, 1) == "3") good_timer = true;
                                        }
                                    }
                                    if (good_timer)
                                    {
                                        Debug.Log("Done");
                                        GameObject.Find("button").SetActive(false);
                                        GameObject.Find("SmallIntestine_Plane.004").SetActive(false);
                                    }
                                    else
                                    {
                                        if (GameObject.Find("Main Camera").GetComponent<strikeScript>().nbstrike > 0)
                                            GameObject.Find("Main Camera").GetComponent<strikeScript>().nbstrike--;
                                        else Debug.Log("You lose");
                                    }

                                }
                            }
                        }
                        break;
                        case 2:
                        if (Input.GetMouseButtonDown(0))
                        {
                            chrono = Time.time;
                            rend.material = yellow_material_pressed;
                        }
                        if (Input.GetMouseButtonUp(0))
                        {
                            rend.material = yellow_material;
                            if (Physics.Raycast(ray, out hit, 1000))
                            {
                                if (hit.collider.name.Contains("button"))
                                {
                                    if (GameObject.Find("Heart") != null)
                                    {
                                        for (int i = 0; i < timer.text.Length; i++)
                                        {
                                            if (timer.text.Substring(i, 1) == "2") good_timer = true;
                                        }

                                    }
                                    else
                                    {
                                        for (int i = 0; i < timer.text.Length; i++)
                                        {
                                            if (timer.text.Substring(i, 1) == "4") good_timer = true;
                                        }
                                    }
                                    if (good_timer)
                                    {
                                        Debug.Log("Done");
                                        GameObject.Find("button").SetActive(false);
                                        GameObject.Find("SmallIntestine_Plane.004").SetActive(false);
                                    }
                                    else
                                    {
                                        if (GameObject.Find("Main Camera").GetComponent<strikeScript>().nbstrike > 0)
                                            GameObject.Find("Main Camera").GetComponent<strikeScript>().nbstrike--;
                                        else Debug.Log("You lose");
                                    }

                                }
                            }
                        }
                        break;
                    }
                    break;
            }
      
    }
}
