using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStrikes : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            var ray = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.tag == "object")
                {
                    if (GameObject.Find("Canvas").GetComponent<strikeScript>().nbstrike > 0)
                    {
                        GameObject.Find("Canvas").GetComponent<strikeScript>().nbstrike--;
                    }
                }
            }
        }
    }
}
