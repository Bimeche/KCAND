using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutRandomOrgan : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("Organ3").SetActive(false);
        GameObject.Find("Organ4").SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
