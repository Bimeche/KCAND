
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public float rate;
    public bool zoom_objet;
    GameObject MainCamera;
    new Camera camera;
    Vector3 vector;
    // Use this for initialization
    void Start () {
        zoom_objet = false;
        MainCamera = GameObject.Find("Main Camera");
        camera = MainCamera.GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 5))
            {
                if(hit.collider.tag == "body")
                {
                    /* if(!GameObject.Find("organ1").GetComponent<BodyBehaviour>().zoom_organ || !GameObject.Find("organ2").GetComponent<BodyBehaviour>().zoom_organ)
                     {
                         zoom_position = !zoom_position;
                         y_change = -y_change;
                         z_change = -z_change;
                         camera.transform.localPosition = new Vector3(camera.transform.localPosition.x, camera.transform.localPosition.y + y_change, camera.transform.localPosition.z + z_change);
                     }*/
                    if (!zoom_objet)
                    {
                        vector = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z+rate);
                        zoom_objet = !zoom_objet;
                        rate = -rate;
                        camera.transform.position = vector;
                    }
                    else if(GameObject.Find("Organ1").GetComponent<BodyBehaviour>().zoom_organ==0 && GameObject.Find("Organ2").GetComponent<BodyBehaviour>().zoom_organ==0)
                    {
                        vector = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z+rate);
                        zoom_objet = !zoom_objet;
                        rate = -rate;
                        camera.transform.position = vector;
                    }
                    

                }
            }
        }
	}
}
