using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownLetter : MonoBehaviour {
    float speed;
    // Use this for initialization
    void Start () {
		speed = Random.Range(1, 20);
        speed = speed / 2;
        transform.Translate(speed, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(0, -speed, 0);
        //if (transform.position.y < -30)
       // {
        //    transform.Translate(0, 40f, 0);
       // }
    }
}
