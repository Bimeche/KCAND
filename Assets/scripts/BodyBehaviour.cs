using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBehaviour : MonoBehaviour {


    GameObject MainCamera;
    new Camera camera;
    GameObject OrganCamera;
    new Transform organcam;
    public bool zoom_organ;
    public int rate;
    Vector3 vector;
    float x_base_camera;
    float y_base_camera;

    // Use this for initialization
    void Start () {
        zoom_organ = false;
        MainCamera = GameObject.Find("Main Camera");
        camera = MainCamera.GetComponent<Camera>();
        x_base_camera = camera.transform.position.x;
        y_base_camera = camera.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (camera.GetComponent<CameraBehaviour>().zoom_objet)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    if (hit.collider.tag == "Organ1")
                    {
                        OrganCamera = GameObject.Find("Organ1");
                        organcam = OrganCamera.transform;
                        vector = new Vector3(organcam.position.x, organcam.position.y, camera.transform.localPosition.z + rate);
                        camera.transform.localPosition = vector;
                        zoom_organ = !zoom_organ;
                        rate = -rate;
                    }else if(hit.collider.tag == "Organ2")
                    {
                            OrganCamera = GameObject.Find("Organ2");
                            organcam = OrganCamera.transform;
                            vector = new Vector3(organcam.position.x, organcam.position.y, camera.transform.localPosition.z + rate);
                            camera.transform.localPosition = vector;
                            zoom_organ = !zoom_organ;
                            rate = -rate;
                        
                    }
                    else if(hit.collider.tag == "body" && zoom_organ)
                    {
                        vector = new Vector3(x_base_camera, y_base_camera, camera.transform.position.z + rate);
                        camera.transform.position = vector;
                        zoom_organ = !zoom_organ;
                        rate = -rate;
                    }
                }
            }
        }
    }  
}
