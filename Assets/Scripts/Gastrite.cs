using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gastrite : MonoBehaviour {

	public GameObject glace;
	public GameObject chocolat;
	public GameObject pate;
	private int actualCase;

	// Use this for initialization
	void Start () {
		actualCase = Random.Range(0, 3);

		switch (actualCase)
		{
                case 0:
                    glace.GetComponent<Renderer>().enabled = true;
                    chocolat.GetComponent<Renderer>().enabled = true;
                    pate.GetComponent<Renderer>().enabled = false;
                    break;
                case 1:
                    glace.GetComponent<Renderer>().enabled = false;
                    chocolat.GetComponent<Renderer>().enabled = true;
                    pate.GetComponent<Renderer>().enabled = true;
                    break;
                case 2:
                    glace.GetComponent<Renderer>().enabled = false;
                    chocolat.GetComponent<Renderer>().enabled = false;
                    pate.GetComponent<Renderer>().enabled = true;
                    break;
                case 3:
                    glace.GetComponent<Renderer>().enabled = true;
                    chocolat.GetComponent<Renderer>().enabled = false;
                    pate.GetComponent<Renderer>().enabled = false;
                    break;
                
            }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
