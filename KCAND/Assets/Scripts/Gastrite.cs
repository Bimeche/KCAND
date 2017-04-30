using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Gastrite : MonoBehaviour {

	public GameObject glace;
	public GameObject chocolat;
	public GameObject pate;
    public TextMesh text;
    public TextMesh L1;
    public TextMesh L2;
    public TextMesh L3;
    public TextMesh L4;
    public TextMesh L5;
    public TextMesh L6;
    public TextMesh L7;
    public TextMesh L8;
    private int actualCase;
    private int rand;
    private string word;
    private string written;
	private List<Transform> all;
	private Camera sceneCamera;
	private bool isCure;
    private AudioSource achievement;

    // Use this for initialization
    void Start () {
		isCure = false;
        achievement = GameObject.Find("achievement").GetComponent<AudioSource>();
        sceneCamera = FindObjectOfType<Camera>();
		all = new List<Transform> ();
		foreach (Transform t in  GetComponentsInParent<Transform>()) {
			all.Add (t);
			t.gameObject.SetActive (false);
		}

		actualCase = Random.Range(0, 3);
        rand = Random.Range(1, 3);
        switch (actualCase)
		{
                case 0:
                    glace.GetComponent<Renderer>().enabled = true;
                    chocolat.GetComponent<Renderer>().enabled = true;
                    pate.GetComponent<Renderer>().enabled = false;
                switch (rand)
                {
                    case 1:
                        word = "SEULE";
                        L1.text = "S";
                        L2.text = "E";
                        L3.text = "U";
                        L4.text = "L";
                        L5.text = "E";
                        L6.text = "B";
                        L7.text = "I";
                        L8.text = "V";

                        break;
                    case 2:
                        word = "CELIBAT";
                        L1.text = "C";
                        L2.text = "E";
                        L3.text = "I";
                        L4.text = "L";
                        L5.text = "E";
                        L6.text = "B";
                        L7.text = "A";
                        L8.text = "T";
                        break;
                    case 3:
                        word = "DIVORCE";
                        L1.text = "O";
                        L2.text = "E";
                        L3.text = "R";
                        L4.text = "C";
                        L5.text = "D";
                        L6.text = "B";
                        L7.text = "I";
                        L8.text = "V";
                        break;
                }
              
                    break;
                case 1:
                    glace.GetComponent<Renderer>().enabled = false;
                    chocolat.GetComponent<Renderer>().enabled = true;
                    pate.GetComponent<Renderer>().enabled = true;
                switch (rand)
                {
                    case 1:
                        word = "SPORT";
                        L1.text = "S";
                        L2.text = "T";
                        L3.text = "P";
                        L4.text = "L";
                        L5.text = "E";
                        L6.text = "R";
                        L7.text = "O";
                        L8.text = "V";
                        break;
                    case 2:
                        word = "TOURNOI";
                        L1.text = "S";
                        L2.text = "O";
                        L3.text = "N";
                        L4.text = "R";
                        L5.text = "U";
                        L6.text = "O";
                        L7.text = "I";
                        L8.text = "T";
                        break;
                    case 3:
                        word = "COMPET";
                        L1.text = "S";
                        L2.text = "M";
                        L3.text = "C";
                        L4.text = "O";
                        L5.text = "E";
                        L6.text = "P";
                        L7.text = "I";
                        L8.text = "T";
                        break;
                }
                break;
                case 2:
                    glace.GetComponent<Renderer>().enabled = false;
                    chocolat.GetComponent<Renderer>().enabled = false;
                    pate.GetComponent<Renderer>().enabled = true;
                switch (rand)
                {
                    case 1:
                        word = "CONTROLE";
                        L1.text = "C";
                        L2.text = "N";
                        L3.text = "R";
                        L4.text = "L";
                        L5.text = "E";
                        L6.text = "O";
                        L7.text = "T";
                        L8.text = "O";
                        break;
                    case 2:
                        word = "CONCOURS";
                        L1.text = "C";
                        L2.text = "O";
                        L3.text = "N";
                        L4.text = "C";
                        L5.text = "R";
                        L6.text = "U";
                        L7.text = "O";
                        L8.text = "C";
                        break;
                    case 3:
                        word = "REVISION";
                        L1.text = "R";
                        L2.text = "E";
                        L3.text = "I";
                        L4.text = "S";
                        L5.text = "O";
                        L6.text = "N";
                        L7.text = "I";
                        L8.text = "V";
                        break;
                }
                break;
                case 3:
                    glace.GetComponent<Renderer>().enabled = true;
                    chocolat.GetComponent<Renderer>().enabled = false;
                    pate.GetComponent<Renderer>().enabled = false;
                switch (rand)
                {
                    case 1:
                        word = "HORREUR";
                        L1.text = "H";
                        L2.text = "O";
                        L3.text = "U";
                        L4.text = "R";
                        L5.text = "E";
                        L6.text = "R";
                        L7.text = "I";
                        L8.text = "R";
                        break;
                    case 2:
                        word = "PEUR";
                        L1.text = "R";
                        L2.text = "E";
                        L3.text = "U";
                        L4.text = "L";
                        L5.text = "E";
                        L6.text = "B";
                        L7.text = "I";
                        L8.text = "P";
                        break;
                    case 3:
                        word = "TENSION";
                        L1.text = "S";
                        L2.text = "E";
                        L3.text = "T";
                        L4.text = "N";
                        L5.text = "O";
                        L6.text = "B";
                        L7.text = "I";
                        L8.text = "N";
                        break;
                }
                break;
                
            }
		Debug.Log (word);
	}
	public void DisplayDisease(){
		if (!isCure) {
			Debug.Log (this.name);
			foreach (Transform t in  all) {
				t.gameObject.SetActive (true);
			}
		}

	}

	public void HideDisease(){

		Debug.Log (this.name);
		foreach (Transform t in  all) {
			t.gameObject.SetActive (false);
		}


	}

	// Update is called once per frame
	void Update () {
		
        foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {
                if (kcode.ToString() == "Backspace")
                {
                    written=written.Substring(0, written.Length - 1);
                }
                else if (kcode.ToString() == "Return")
                {
					if (!isCure) {
						if (word == written) {
							Debug.Log ("Done");
                            achievement.Play();
                            this.HideDisease ();
							isCure = true;

						} else {
							sceneCamera.GetComponent<strikeScript> ().nbstrike--;
							if (sceneCamera.GetComponent<strikeScript> ().nbstrike == 0){
								NavigationBetweenScenes end = FindObjectOfType<NavigationBetweenScenes> ();
								end.SetLose ();
								end.GameOver ();
							}
								
						}
					}
                }
                else if (kcode.ToString().Length ==1)
                {
                    written = written + kcode.ToString();
                }
                text.text = written;
            }
              
        }

    }
}
