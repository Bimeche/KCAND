using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBehaviour : MonoBehaviour {


    GameObject MainCamera;
    new Camera camera;
    bool zoom_organ = false;
    float x_change;
    float y_change;
    float z_change;

    // Use this for initialization
    void Start () {
        MainCamera = GameObject.Find("Main Camera");
        camera = MainCamera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        if (camera.GetComponent<CameraBehaviour>().zoom_position && !zoom_organ)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    if (hit.collider.tag == "organ1")
                    {
                        x_change = 0.5f;
                        y_change = -1.2f;
                        z_change = 3.3f;
                        camera.transform.localPosition = new Vector3(camera.transform.localPosition.x, camera.transform.localPosition.y + y_change, camera.transform.localPosition.z + z_change);
                    }else if(hit.collider.tag == "organ2")
                    {
                        x_change = 0.5f;
                        y_change = -1.2f;
                        z_change = 2.9f;
                        camera.transform.localPosition = new Vector3(camera.transform.localPosition.x, camera.transform.localPosition.y + y_change, camera.transform.localPosition.z + z_change);
                    }
                }
                //racemanager = GameObject.Find("Racemanager").GetComponent<RaceManager>();
                else if (camera.GetComponent<CameraBehaviour>().zoom_position && zoom_organ)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        ray = camera.ScreenPointToRay(Input.mousePosition);

                        if (Physics.Raycast(ray, out hit, 100))
                        {
                            if (hit.collider.tag == "body")
                            {
                                x_change = -x_change;
                                y_change = -y_change;
                                z_change = -z_change;
                                camera.transform.localPosition = new Vector3(camera.transform.localPosition.x, camera.transform.localPosition.y + y_change, camera.transform.localPosition.z + z_change);
                            }
                        }
                    }
                }
            }
        }
    }
}
