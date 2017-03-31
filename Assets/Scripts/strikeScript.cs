using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class strikeScript : MonoBehaviour {

    public int nbstrike;
    Image strike1;
    Image strike2;
    Image strike3;
    // Use this for initialization
    void Start () {
        nbstrike = 3;
        strike3 = GameObject.Find("strike1").GetComponent<Image>();
        strike2 = GameObject.Find("strike2").GetComponent<Image>();
        strike1 = GameObject.Find("strike3").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        if(nbstrike == 2)
        {
            strike1.enabled = false;
        }else if(nbstrike == 1)
        {
            strike2.enabled = false;
        }else if(nbstrike == 0)
        {
            strike3.enabled = false;
        }
    }
}
