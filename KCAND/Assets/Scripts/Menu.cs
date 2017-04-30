using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class Menu : MonoBehaviour {

	private GameObject mainMenu;
	private GameObject levelSelection;


	// Use this for initialization
	void Start () {
		mainMenu = GameObject.FindGameObjectWithTag("MainMenu");
		mainMenu.SetActive(true);
		
		levelSelection = GameObject.FindGameObjectWithTag("LevelSelection");
		levelSelection.SetActive(false);

	}

	// Update is called once per frame
	void Update () {
		
	}

    public void ClickPlay()
    {
		Debug.Log(mainMenu.tag);
		mainMenu.SetActive(false);
		levelSelection.SetActive(true);
    }

    public void ClickCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ClickQuit()
    {
        Application.Quit();
    }

	public void ClickLevels()
	{
		//SceneManager.LoadScene("SceneLeo");
		NavigationBetweenScenes temp = FindObjectOfType<NavigationBetweenScenes>();
		temp.ChangeLevel(EventSystem.current.currentSelectedGameObject.name);
	}

	public void ClickBack()
	{
		mainMenu.SetActive(true);
		levelSelection.SetActive(false);
	}
}
