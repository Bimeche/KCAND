/*
	This script is assigned to the right hand of the player, basically helping for recharge animations of the player.
	Here, when the right hand trigger with "BulletsPointEnable" gameobject, the "Pack of bullets" appears, and when trigger with "Bulletspoint" dissapears.
*/
 
using UnityEngine;
using System.Collections;

public class FakeBullets : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.name=="BulletsPointEnable"){
			GetComponent<Renderer>().enabled=true;
		}
		if(other.gameObject.name=="BulletsPoint"){
			GetComponent<Renderer>().enabled=false;
			GameObject go = Instantiate(other.gameObject, other.gameObject.transform.position, other.gameObject.transform.rotation)as GameObject;
			go.transform.parent=other.gameObject.transform.parent;
			go.transform.localScale = other.gameObject.transform.localScale;
			go.GetComponent<Renderer>().enabled=true;
			go.GetComponent<Rigidbody>().isKinematic=true;
			go.GetComponent<Rigidbody>().useGravity=true;
			go.name="Bullets";
			Invoke("GetRecharge",1);
		}
	}

	void GetRecharge(){GameObject.Find("Player").SendMessage("CreateRecharge");}
}
