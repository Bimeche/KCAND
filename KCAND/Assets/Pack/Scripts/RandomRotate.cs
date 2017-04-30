/*
	Basically used to set a random rotation to the blood, and destroy them.
*/

using UnityEngine;
using System.Collections;

public class RandomRotate : MonoBehaviour {
	int x,y,z=0;
	float speed=0;
	GameObject child;
	private bool on=false;
	// Use this for initialization
	void Start () {
		x = Random.Range(1,180);
		y = Random.Range(1,180);
		z = Random.Range(1,180);
		child = getChild(this.gameObject);
		speed = Random.Range(1,10);
		Invoke("On_Destroy",5);
	}

	private GameObject getChild(GameObject cam){
		GameObject aux=null;
		foreach(Transform child in cam.gameObject.transform){if(child.name=="default"){aux=child.gameObject;}}
		return aux;
	}

	// Update is called once per frame
	void Update () {
		child.transform.Rotate(Time.deltaTime* x, Time.deltaTime*y, Time.deltaTime*z);
		if(on==false){
			on=true;
			GetComponent<Rigidbody>().AddForce(transform.forward *(-1)*Random.Range(20000,30000));
			GetComponent<Rigidbody>().AddForce(transform.up * Random.Range(30000,40000));
			GetComponent<Rigidbody>().AddForce(transform.right * Random.Range(20000,30000));
			GetComponent<Rigidbody>().AddForce(transform.right *(-1)* Random.Range(20000,30000));
		}
	}

	void On_Destroy(){
		Destroy(this.gameObject);
	}
}
