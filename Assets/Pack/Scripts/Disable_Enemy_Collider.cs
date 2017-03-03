
/*
 [Enemy] 
   If Dying animation, disable Radius collider
*/

using UnityEngine;
using System.Collections;

public class Disable_Enemy_Collider : MonoBehaviour {
	Animator anim;
	public GameObject radius;
	// Use this for initialization
	void Start () {
		anim=GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(anim.GetCurrentAnimatorStateInfo(0).IsName("Dying")){
			radius.GetComponent<Collider>().enabled=false;
		}
	}
}
