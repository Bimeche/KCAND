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
    private Camera sceneCamera;
    private Text timer;
    private FillSheet sheet;
    private int texture;
    private int random_word;
    private bool good_timer = false;
    private Renderer rend;
    private float chrono;
    private int nb;
    private AudioSource achievement;
    // Use this for initialization
    void Start () {

        achievement = GameObject.Find("achievement").GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
        sheet = FindObjectOfType<FillSheet>();
        sceneCamera = FindObjectOfType<Camera>();
        timer = FindObjectOfType<Timer>().GetComponent<Text>();
        texture = sheet.getTexture();
        nb = sheet.getnb();

        if (sheet.getTexture() == 0)
        {
            rend.material = red_material;
        }
        else
        {
            rend.material = yellow_material;
        }
    }

	private void Awake()
	{
        
    }

	public void SetWord(){
		random_word = sheet.getWord();
		word.text = sheet.getWordMesh();
	}

	// Update is called once per frame
	void Update()
    {
        
        var ray = sceneCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        switch (texture)
                 {
                     case 0:			// BOUTON ROUGE
                         switch (random_word)
                         {
                             case 0:			// TEXTE CAFE
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
                                                if (timer.text.Substring(i, 1) == GameObject.FindGameObjectWithTag("sheet").GetComponent<FillSheet>().ligne1.text.Substring(7)) good_timer = true;
                                            }
                                        }
                                    if (good_timer)
                                    {
                                        achievement.Play();
                                        GameObject.FindGameObjectWithTag("button").SetActive(false);
										FindObjectOfType<InstantiateLevelObjects> ().Cured ("Ulcère");
										NavigationBetweenScenes end = FindObjectOfType<NavigationBetweenScenes> ();
										end.ModuleCured ();
									
                                       // GameObject.Find("SmallIntestine_Plane.004").SetActive(false);
                                    }
                                    else
                                    {
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
                            break;
                        case 1:					// TEXTE ALCOOL
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
										FindObjectOfType<InstantiateLevelObjects> ().Cured ("Ulcère");
										NavigationBetweenScenes end = FindObjectOfType<NavigationBetweenScenes> ();
										end.ModuleCured ();
                                        achievement.Play();
                                        GameObject.FindGameObjectWithTag("button").SetActive(false);
                                       // GameObject.Find("SmallIntestine_Plane.004").SetActive(false);
                                    }
                                    else
                                    {
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
                        break;
                        case 2:						// TEXTE TABAC
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
                                    if (int.Parse(GameObject.FindGameObjectWithTag("sheet").GetComponent<FillSheet>().ligne1.text.Substring(6)) < 25)
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
										FindObjectOfType<InstantiateLevelObjects> ().Cured ("Ulcère");
										NavigationBetweenScenes end = FindObjectOfType<NavigationBetweenScenes> ();
										end.ModuleCured ();
                                        achievement.Play();
                                        GameObject.FindGameObjectWithTag("button").SetActive(false);
                                        //GameObject.Find("SmallIntestine_Plane.004").SetActive(false);
                                    }
                                    else
                                    {
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
                        break; 
                    }
                    break;
                case 1:					// BOUTON JAUNE
                    switch (random_word)
                    {
                        case 0:						// TEXTE CAFE
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
                                    if (GameObject.Find("NavObject").GetComponent<NavigationBetweenScenes>().getNbMod() ==2)
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
										FindObjectOfType<InstantiateLevelObjects> ().Cured ("Ulcère");
										NavigationBetweenScenes end = FindObjectOfType<NavigationBetweenScenes> ();
										end.ModuleCured ();
                                        achievement.Play();
                                        GameObject.FindGameObjectWithTag("button").SetActive(false);
                                        //GameObject.Find("SmallIntestine_Plane.004").SetActive(false);
                                    }
                                    else
                                    {
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
                        break;
                        case 1:						// TEXTE ALCOOL
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
                                    if (int.Parse(GameObject.FindGameObjectWithTag("sheet").GetComponent<FillSheet>().ligne1.text.Substring(6)) < 50)
                                    {
                                        for (int i = 0; i < timer.text.Length; i++)
                                        {
                                            if (timer.text.Substring(i, 1) == GameObject.FindGameObjectWithTag("sheet").GetComponent<FillSheet>().ligne1.text.Substring(7)) good_timer = true;
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
										FindObjectOfType<InstantiateLevelObjects> ().Cured ("Ulcère");
										NavigationBetweenScenes end = FindObjectOfType<NavigationBetweenScenes> ();
										end.ModuleCured ();
                                        achievement.Play();
                                        GameObject.FindGameObjectWithTag("button").SetActive(false);
                                        //GameObject.Find("SmallIntestine_Plane.004").SetActive(false);
                                    }
                                    else
                                    {
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
                        break;
                        case 2:						// TEXTE TABAC
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
                                    if (GameObject.Find("NavObject").GetComponent<NavigationBetweenScenes>().getNbMod() == 2)
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

										FindObjectOfType<InstantiateLevelObjects> ().Cured ("Ulcère");
										NavigationBetweenScenes end = FindObjectOfType<NavigationBetweenScenes> ();
										end.ModuleCured ();
                                        achievement.Play();
                                        GameObject.FindGameObjectWithTag("button").SetActive(false);
                                        //GameObject.Find("SmallIntestine_Plane.004").SetActive(false);
                                    }
                                    else
                                    {
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
                        break;
                    }
                    break;
            }
      
    }
}
