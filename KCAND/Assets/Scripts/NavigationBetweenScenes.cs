using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavigationBetweenScenes : MonoBehaviour {
	private Image feuille;
	private Text niveau;
	private Text nbModules;
	private Text temps;
	private Text strike;
	private int nbMod;

	// Use this for initialization
	private string levelName;
	private string timeSpent;
	private bool win;

	private Text niveauR;
	private Text nbModulesR;
	private int moduleCured;


	void Start () {
		moduleCured = 0;
	}

	public void Initialisation(){
		
		if (SceneManager.GetActiveScene ().name == "Morgane") {

			GameObject levelSelection = GameObject.FindGameObjectWithTag ("LevelSelection");

			foreach (Image g in levelSelection.GetComponentsInChildren<Image>()) {
				if (g.name == "Feuille")
					feuille = g;
			}
			levelSelection.SetActive (false);
		}
		DontDestroyOnLoad(gameObject);

		if(feuille)
			feuille.gameObject.SetActive (false);


		foreach (Text g in feuille.GetComponentsInChildren<Text>()) {
			if (g.name == "niveau")
				niveau = g;
			else if (g.name == "NbModules")
				nbModules = g;
			else if (g.name == "temps")
				temps = g;
			else if (g.name == "strike")
				strike = g;

		}
	}


	// Update is called once per frame
	void Update () {
	}

	public void ChangeLevel(string value)
	{
		feuille.gameObject.SetActive (true);
		moduleCured = 0;
		win = true;
		switch (value) {
		case "Level1":
			niveau.text = "Niveau 1";
			nbModules.text = "Nombre de maladies : 1";
			temps.text = "Temps : 50 secondes";
			strike.text = "Vies : 2";
			nbMod = 1;
			break;
		case "Level2":
			niveau.text = "Niveau 2";
			nbModules.text = "Nombre de maladies : 1";
			temps.text = "Temps : 40 secondes";
			strike.text = "Vie : 1";
			nbMod = 1;
			break;
		case "Level3":
			niveau.text = "Niveau 3";
			nbModules.text = "Nombre de maladies : 2";
			temps.text = "Temps : 1 minute 30";
			strike.text = "Vies : 3";
			nbMod = 2;
			break;

		}
		niveauR = niveau;
		nbModulesR = nbModules;
		levelName = value;
	}

	public Text getNiveauR(){
		return niveauR;
	}

	public Text getNbModulesR(){
		return nbModulesR;
	}

	public int GetLvlTime(){
		return int.Parse (temps.text);
	}

	public void Change(){
		win = true;
		timeSpent = "0";
		moduleCured = 0;
		SceneManager.LoadScene("SceneLeo");
	}

	public void Retour(){
		feuille.gameObject.SetActive (false);
	}

	public string GetLevelName()
	{
		return levelName;
	}

	public void BackToMenu()
	{
		SceneManager.LoadScene("Morgane");
	}

	public string GetTimeSpent(){
		return timeSpent;
	}

	public bool GetWin(){
		return win;
	}

	public void SetLose(){
		 win = false;
	}
	public int getNbMod(){
		return nbMod;
	}
	public void GameOver(){
		Timer time = FindObjectOfType<Timer> ();
		timeSpent = time.getTime ().text;
		SceneManager.LoadScene("Lose");
	}

	public void ModuleCured(){
		Debug.Log (moduleCured + "  " + nbMod);
		moduleCured++;
		if (moduleCured == nbMod)
			GameOver ();
	}
}
