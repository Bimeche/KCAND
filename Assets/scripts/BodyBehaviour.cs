using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBehaviour : MonoBehaviour {


    GameObject MainCamera;
    GameObject squelette;
    new Camera camera;
    GameObject OrganCamera;
    new Transform organcam;
    public int zoom_organ=0;
    bool zoom_sheet = false;
    public float rate = 1.5f;
    Vector3 vector;
    Quaternion quat;
    float x_base_camera;
    float z_base_camera;
    public float rotx = -90;

    // Use this for initialization
    void Start () {
        MainCamera = GameObject.Find("Main Camera");
        camera = MainCamera.GetComponent<Camera>();
        x_base_camera = camera.transform.position.x;
        z_base_camera = camera.transform.position.z;
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
                    if (hit.collider.tag == "Organ1" && zoom_organ != 1)
                    {
                        zoom_organ = 1;
                        squelette =GameObject.Find("Skeleton_Cube");
                        squelette.SetActive(false);
                        OrganCamera = GameObject.Find("Heart");
                        organcam = OrganCamera.transform;
                        vector = new Vector3(organcam.position.x,MainCamera.transform.position.y - rate, organcam.position.z);
                        MainCamera.transform.position = vector;
                        rate = -rate;
                    }
                    /*else if (hit.collider.tag == "Organ2" && zoom_organ != 1)
                    {
                        Debug.Log("ici 2");
                        OrganCamera = GameObject.Find("Organ2");
                        organcam = OrganCamera.transform;
                        vector = new Vector3(organcam.position.x, organcam.position.y, MainCamera.transform.position.z + rate);
                        MainCamera.transform.position = vector;
                        zoom_organ = 1;
                        rate = -rate;
                    }*/
                    else if (hit.collider.tag == "body" && zoom_organ == 1)
                    {
                        Debug.Log("ici 3");
                        vector = new Vector3(x_base_camera, camera.transform.position.y - rate, z_base_camera );
                        camera.transform.position = vector;
                        zoom_organ = 2;
                        rate = -rate;
                    }
                    else if (hit.collider.tag == "body" && zoom_organ == 2)
                    {
                        Debug.Log("ici 4");
                        zoom_organ = 0;
                    }
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    if (hit.collider.tag == "sheet" && !zoom_sheet)
                    {
                        OrganCamera = GameObject.Find("sheet");
                        organcam = OrganCamera.transform;
                        vector = new Vector3(organcam.position.x,MainCamera.transform.position.y - 0.6f, organcam.position.z);
                        MainCamera.transform.position = vector;
                        quat = Quaternion.Euler(rotx,0,0);
                        organcam.transform.rotation = quat;
                        zoom_sheet = !zoom_sheet;
                    }
                    else if (hit.collider.tag == "sheet" && zoom_sheet)
                    {
                        vector = new Vector3(x_base_camera, camera.transform.position.z + 0.6f, z_base_camera);
                        camera.transform.position = vector;
                        quat = Quaternion.Euler(0,0,0);
                        organcam.transform.rotation = quat;
                        zoom_sheet = !zoom_sheet;
                    }
                }
            }
        }
    }  
}
