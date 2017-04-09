using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class strikeScript : MonoBehaviour {

    public int nbstrike;
    Image strike1;
    Image strike2;
    Image strike3;
    private bool once;
    private bool once2;
    private bool once3;
    public AudioSource sound1;
    public AudioSource sound2;
    public AudioSource sound3;
    public AudioSource sound4;
    public AudioSource ambiance;
    // Use this for initialization
    void Start () {
        nbstrike = 3;
        once = once3 = once2 = true;
        //sound1.Play();
        strike3 = GameObject.Find("strike1").GetComponent<Image>();
        strike2 = GameObject.Find("strike2").GetComponent<Image>();
        strike1 = GameObject.Find("strike3").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        if(nbstrike == 2)
        {
            if (once)
            {
                sound1.Stop();
                sound2.Play();
                once = !once;
            }
            strike1.enabled = false;
        }else if(nbstrike == 1)
        {
            if (once2)
            {
                sound2.Stop();
                sound3.Play();
                once2 = !once2;
            }
            strike2.enabled = false;
        }else if(nbstrike == 0)
        {
            if (once3)
            {
                sound3.Stop();
                ambiance.Stop();
                sound4.Play();
                once3 = !once3;
            }
            strike3.enabled = false;
        }
    }
}
