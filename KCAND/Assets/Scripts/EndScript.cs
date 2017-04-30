using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour {

	private NavigationBetweenScenes nav;
	public Text niveau;
	public Text nbModules;
	public Text	temps;
	public Image soigne;
	public Image mort;

	// Use this for initialization
	void Start () {
		nav = FindObjectOfType<NavigationBetweenScenes>();

		niveau.text = nav.getNiveauR().text;
		nbModules.text = nav.getNbModulesR().text;
		temps.text = "Temps restant : " + nav.GetTimeSpent ();

		if (nav.GetWin ()) {
			mort.gameObject.SetActive (false);
			soigne.gameObject.SetActive (true);
		} else {
			soigne.gameObject.SetActive (false);
			mort.gameObject.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Retour(){
		SceneManager.LoadScene("Morgane");
	}

}
