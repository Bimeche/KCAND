using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gastrite : MonoBehaviour {

	public GameObject glace;
	public GameObject chocolat;
	public GameObject pate;
    public TextMesh text;
	private int actualCase;
    private int rand;
    private string word;
    private string written;

	// Use this for initialization
	void Start () {
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
                        break;
                    case 2:
                        word = "CELIBAT";
                        break;
                    case 3:
                        word = "DIVORCE";
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
                        break;
                    case 2:
                        word = "TOURNOI";
                        break;
                    case 3:
                        word = "COMPET";
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
                        break;
                    case 2:
                        word = "CONCOURS";
                        break;
                    case 3:
                        word = "REVISION";
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
                        break;
                    case 2:
                        word = "PEUR";
                        break;
                    case 3:
                        word = "TENSION";
                        break;
                }
                break;
                
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
                    if (word == written)
                    {

                    }else
                    {

                    }
                }
                else
                {
                    written = written + kcode.ToString();
                }
                text.text = written;
            }
              
        }

    }
}
