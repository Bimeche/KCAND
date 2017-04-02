using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FillSheet : MonoBehaviour {

    public TextMesh ligne1;
    public TextMesh ligne2;
    public TextMesh ligne3;
    public TextMesh ligne4;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FillDocument(string inf1, string inf2, string inf3, string inf4)
    {
        ligne1.text = inf1;
        ligne2.text = inf2;
        ligne3.text = inf3;
        ligne4.text = inf4;
    }
}
