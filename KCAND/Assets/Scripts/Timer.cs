using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour {


    private float timeLevel;
    public Text timedisplay;
    float minutes = 0;
    float secondes;
    public SoundManager sm;
    int secondtmp;
    public AudioSource bip;

    // Use this for initialization
    void Start () {
		NavigationBetweenScenes nav = GameObject.FindObjectOfType<NavigationBetweenScenes> ();

		if (nav.GetLevelName() == "Level1")
        {
            timeLevel = 50;
        }
		else if (nav.GetLevelName() == "Level2")
        {
            timeLevel = 40;
        }
        else
        {
            timeLevel = 90;
        }

        secondes = timeLevel;
        while (secondes > 59)
        {
            minutes++;
            secondes = secondes - 60;
        }

        secondtmp = Mathf.FloorToInt(secondes);
        if (secondes < 10)
            timedisplay.text = minutes.ToString() + " : 0" + secondes.ToString("F0");
        else
            timedisplay.text = minutes.ToString() + " : " + secondes.ToString("F0");

    }
	
	// Update is called once per frame
	void Update () {
        
        secondes -= Time.deltaTime;
        if (secondtmp != Mathf.FloorToInt(secondes))
        {
            secondtmp = Mathf.FloorToInt(secondes);
            //sm.PlaySingle(bip.clip);
            if(minutes == 0)
            {
                if(secondes < 0)
                {
                    timedisplay.text = minutes.ToString() + " : 00";
                    TimeOver();
                }else if(secondes < 10)
                {
                    timedisplay.text = minutes.ToString() + " : 0" + secondes.ToString("F0");
                }else
                {
                    timedisplay.text = minutes.ToString() + " : " + secondes.ToString("F0");
                }
            }else
            {
				if((int)secondes < 0)
                {
                    secondes = 59;
                    minutes--;
                }

				if (Mathf.CeilToInt(secondes) < 10)
					timedisplay.text = minutes.ToString() + " : 0" + secondes.ToString("F0");
				else
					timedisplay.text = minutes.ToString() + " : " + secondes.ToString("F0");
				
            }

        }


	}

    void TimeOver()
    {
		NavigationBetweenScenes end = FindObjectOfType<NavigationBetweenScenes> ();
		end.SetLose ();
		end.GameOver ();
    }

	public Text getTime(){
		return timedisplay;
	}
}


