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
    private int texture;
    private int random_word;
    private bool good_timer;
    private Renderer rend;
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
                                                if (timer.text.Substring(i, 1) == GameObject.Find("sheet").GetComponent<FillSheet>().ligne1.text.Substring(1, 1)) good_timer = true;
                                            }
                                        }   
                                        if (good_timer)
                                        {
                                            SceneManager.LoadScene("Win");
                                        }
                                        else
                                        {
                                            SceneManager.LoadScene("Lose");
                                        }

                                     }
                                 }
                              }
                            break;
                        case 1:
                            break;
                        case 2:
                            break; 
                    }
                    break;
                case 1:
                    switch (random_word)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                    }
                    break;
            }
      
    }
}
