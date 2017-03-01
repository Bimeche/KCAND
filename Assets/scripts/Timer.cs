using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour {


    public float timeLevel = 30;
    public Text timedisplay;
    float minutes;
    float secondes;
	// Use this for initialization
	void Start () {

        secondes = timeLevel;
        while (secondes > 59)
        {
            minutes++;
            secondes = secondes - 60;
        }

        if (secondes < 10)
            timedisplay.text = minutes.ToString() + " : 0" + secondes.ToString("F0");
        else
            timedisplay.text = minutes.ToString() + " : " + secondes.ToString("F0");

    }
	
	// Update is called once per frame
	void Update () {
		
        secondes -= Time.deltaTime;
        if (secondes < 0)
        {
            secondes = 59;
            minutes--;
        }

        if(secondes<10)
            timedisplay.text = minutes.ToString() + " : 0" + secondes.ToString("F0");
        else
            timedisplay.text = minutes.ToString() + " : " + secondes.ToString("F0");

        if (minutes < 0)
        {
            TimeOver();
        }

	}

    void TimeOver()
    {
        Debug.Log("Finnish");
    }
}


