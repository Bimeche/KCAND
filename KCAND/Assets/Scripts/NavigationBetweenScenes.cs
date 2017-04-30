using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavigationBetweenScenes : MonoBehaviour {
	public Image feuille;
	public Text niveau;
	public Text nbModules;
	public Text	temps;
    public Text strike;

	// Use this for initialization
	private string levelName;
	private string timeSpent;
	private bool win;

	private Text niveauR;
	private Text nbModulesR;



	void Start () {
		DontDestroyOnLoad(gameObject);
		if(feuille)
		feuille.gameObject.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeLevel(string value)
	{
		feuille.gameObject.SetActive (true);

		switch (value) {
		case "Level1":
			niveau.text = "Niveau 1";
			nbModules.text = "Nombre de maladies : 1";
			temps.text = "Temps : 30 secondes";
                strike.text = "Vies : 2";
			break;
		case "Level2":
			niveau.text = "Niveau 2";
			nbModules.text = "Nombre de maladies : 1";
			temps.text = "Temps : 25 secondes";
                strike.text = "Vie : 1";
			break;
		case "Level3":
			niveau.text = "Niveau 3";
			nbModules.text = "Nombre de maladie : 2";
			temps.text = "Temps : 50 secondes";
                strike.text = "Vies : 3";
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

	public void Change(){
		win = true;
		timeSpent = "0";
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

	public void GameOver(){
		Timer time = FindObjectOfType<Timer> ();
		timeSpent = time.getTime ().text;
		SceneManager.LoadScene("Lose");
	}
}
