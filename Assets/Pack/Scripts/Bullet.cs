/*
	Basically used to bullet movement, setting slow motion and blood creation.
	
	Very Important!!!! 
	If you change the timestep/timescale values or speed values, maybe that the collision event might not be detected correctly. More speed needs a low timestep.
*/

using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public int speed = 1000;
	public GameObject Camera1;
	public GameObject Cam1_over;
	public GameObject Camera2;
	public GameObject Cam2_over;
	private int aux=0;
	private bool stay=false;
	private GameObject auxgo=null;

	// Use this for initialization
	void Start () {
		aux = Random.Range(1,3);	//Camera random 1 or 2
		aux=2; 						//Camera 2 by default, if you want random, delete this line
		switch(aux){
		case 1:
			Camera1.GetComponent<Camera>().enabled=true;
			break;
		case 2:
			Camera2.GetComponent<Camera>().enabled=true;
			break;
		}
		Invoke("Destroy_",1.8f);
		Time.fixedDeltaTime = 0.01F;
		Time.maximumDeltaTime = 0.01F;
		//speed=0;
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.name=="Limit"){Destroy_();}
		if(other.gameObject.name=="neck"||other.gameObject.name=="chest"||other.gameObject.name=="head"){
			other.transform.root.GetComponent<Animator>().SetBool("kill",true);
			Invoke("CreateBlood",0.0005f);
			speed=666;
		}
		if(other.gameObject.name=="Radius"){
			auxgo=other.transform.root.gameObject;
			SlowMotionR(true);
		}
		if(other.gameObject.name=="hips"){

			switch(aux){
			case 1:
				Cam1_over.GetComponent<Renderer>().enabled=true;
				break;
			case 2:
				Cam2_over.GetComponent<Renderer>().enabled=true;
				break;
			}
			SlowMotion(true);
		}
	}

	void OnTriggerExit(Collider other) {
		Time.timeScale = 0.05F;
		Time.fixedDeltaTime = 0.01F * Time.timeScale;
	}

	void Update () {
		transform.Translate(Vector3.back* Time.deltaTime *speed);
	}

	void CreateBlood(){StartCoroutine(CreateBlood_());}
	IEnumerator CreateBlood_(){
		for(int i = 0; i<30;i++){										//You can add more blood, by setting a bigger bucle
			if(speed!=10&&speed!=667){
				GameObject go = Instantiate(Resources.Load("Blood/Blood" + Random.Range(1,9)), transform.position, Quaternion.Euler( Random.Range(0, 360) , Random.Range(0, 360) ,Random.Range(0, 360)))as GameObject;
			}
			yield return new WaitForSeconds(Random.Range(0,0.00009f));	//Time between bloods creation
		}
	}

	private void SlowMotionR(bool on){		//Timescale changed
		if (on == true)
			Time.timeScale = 0.02F;
		else
			Time.timeScale = 1.0F;
		Time.fixedDeltaTime = 0.02F * Time.timeScale;
	}

	private void SlowMotion(bool on){		//Timescale changed
		if (on == true)
			Time.timeScale = 0.003F;
		else
			Time.timeScale = 1.0F;
		Time.fixedDeltaTime = 0.01F * Time.timeScale;
	}

	private GameObject getChild(GameObject cam){
		GameObject aux=null;
		foreach(Transform child in cam.gameObject.transform){if(child.name=="Over"){aux=child.gameObject;}}
		return aux;
	}

	void Destroy_(){	//Destroy bullet and reset the timescale
		Time.timeScale = 1.0F;
		Time.fixedDeltaTime = 0.03F * Time.timeScale;
		Time.maximumDeltaTime = 0.03F;
		Destroy(this.gameObject);
	}
}
