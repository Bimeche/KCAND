using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//========= About this script ==========================//
//Used to move the player through the scene				//
//Shooting and recharge									//
//Shift to stop breathing								//
//Right mouse button to point with the rifle			//
//R recharge bullet										//
//T recharge pack of bullets							//
//======================================================//

public class CameraMoveController : MonoBehaviour {
	public GameObject spawner;				//Bullets spawn
	public float speedH = 2.0f;				//player movement
	public float speedV = 2.0f;
	public float speed = 6.0F;
	public GameObject RightShoulder;
	public GameObject RechargeTube;
	public GameObject bulletsFake;
	public GameObject bulletsPoint;
	private float auxSpeed = 0;
	private float auxSpeedH;
	private float auxSpeedV;
	private float yaw = 0.0f;
	private float pitch = 0.0f;
	private float zvar = 0.0f;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection ;
	private Vector3 moveDirection2;
	private bool stop = true;
	private Vector3 aux;
	private Text text_;
	private float latestyaw;
	private bool point=false; // point the gun
	//---Animator controllers
	private Animator gun_anim;
	private Animator uppL;	//upper
	private Animator uppR;
	private Animator forL;	//forearm
	private Animator forR;

	void Start(){
		Cursor.visible = false;
		Screen.lockCursor = true;
		yaw= Camera.main.transform.eulerAngles.x;
		pitch=transform.eulerAngles.y;
		auxSpeed = speed;
		auxSpeedH = speedH;
		auxSpeedV = speedV;
		gun_anim= GameObject.Find("Rif").GetComponent<Animator>();
		Time.timeScale = 1.0F;
		Time.fixedDeltaTime = 0.03F * Time.timeScale;
		Time.maximumDeltaTime = 0.03F;
	}


	void Update() {
		//About buttons pressing=======//
		//=============================//

		if(Input.GetKeyDown(KeyCode.LeftShift)){gun_anim.enabled=false;}
		if(Input.GetKeyUp(KeyCode.LeftShift)){gun_anim.enabled=true;}
		if(Input.GetKeyUp("r")){CreateRecharge();}
		if(Input.GetKey("q")){SceneManager.LoadScene("SniperView");}
		if(Input.GetKey(KeyCode.Escape)){UnityEditor.EditorApplication.isPlaying = false;}
		if(Input.GetKeyUp("t")){
			GameObject bullets = GameObject.Find("Bullets");
			bullets.transform.parent = GameObject.Find("Environment").transform;
			bullets.GetComponent<Rigidbody>().isKinematic=false;
			RightShoulder.GetComponent<Animator>().SetBool("bullets",true);
			Invoke("DisbleRechargeBullets",0.1f);
			Invoke("DestroyBullets",3);
		}
		if(Input.GetMouseButtonDown(0)&&!GameObject.Find("Bullet")){
			GameObject go = Instantiate(Resources.Load("Bullet/Bullet"), spawner.transform.position, Quaternion.identity)as GameObject;
			go.name="Bullet";
			go.transform.rotation = spawner.transform.rotation;
		}
		if(Input.GetMouseButtonDown(1)){
			point=!point;
			if(point==true){			//If point with rifle, speed down
				gun_anim.SetBool("point",true);
				Invoke("Blur",0.7f);
				speed=speed/7;
				speedH=speedH/13;
				speedV=speedV/13;
			}else{
				gun_anim.SetBool("point",false);
				speed = auxSpeed;
				speedH= auxSpeedH;
				speedV= auxSpeedV;
				Invoke("NoBlur",0.5f);
			}
		}
		//About movement============//
		//==========================//

		if(Input.GetAxis("Mouse X")!=0||Input.GetAxis("Mouse Y")!=0){stop=false;}
		if(stop==false){
			pitch += speedH * Input.GetAxis("Mouse X");
			yaw -= speedV * Input.GetAxis("Mouse Y");
			if(yaw<70&&yaw>-70){
				latestyaw=yaw;
				transform.eulerAngles = new Vector3(yaw, pitch, 0.0f);
			}else{
				yaw=latestyaw;
				transform.eulerAngles = new Vector3(latestyaw, pitch, 0.0f);
			}
			/*pitch += speedH * Input.GetAxis("Mouse X");
			yaw -= speedV * Input.GetAxis("Mouse Y");
			latestyaw=yaw;
			transform.eulerAngles = new Vector3(0, pitch, 0.0f);
			Camera.main.transform.eulerAngles= new Vector3(yaw, pitch, 0.0f);*/
		}
		//--
		CharacterController controller = GameObject.Find("Player").GetComponent<CharacterController>();
	    moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

	private void NoBlur(){
		MonoBehaviour[] scripts = Camera.main.GetComponents<MonoBehaviour>();
		foreach (MonoBehaviour script in scripts) {
			if(script.GetType ().Name=="DepthOfField"){
				script.enabled=false;
			}
		}
	}
	private void Blur(){
		MonoBehaviour[] scripts = Camera.main.GetComponents<MonoBehaviour>();
		foreach (MonoBehaviour script in scripts) {
			if(script.GetType ().Name=="DepthOfField"){
				script.enabled=true;
			}
		}
	}

	private GameObject getChild(GameObject go, string name){
		GameObject aux=null;
		foreach(Transform child in go.gameObject.transform){if(child.name==name){aux=child.gameObject;}}
		return aux;
	}

	//About Recharge animations
	void DisbleRechargeTube(){
		GameObject.Find("Rif").GetComponent<Animator>().SetBool("play",false);
		RechargeTube.GetComponent<Animator>().SetBool("play",false);
		RightShoulder.GetComponent<Animator>().SetBool("play",false);
	}
	void DisbleRechargeBullets(){
		RightShoulder.GetComponent<Animator>().SetBool("bullets",false);
	}
	public void CreateRecharge(){
		GameObject.Find("Rif").GetComponent<Animator>().SetBool("play",true);
		RechargeTube.GetComponent<Animator>().SetBool("play",true);
		RightShoulder.GetComponent<Animator>().SetBool("play",true);
		Invoke("DisbleRechargeTube",0.1f);
	}
}
