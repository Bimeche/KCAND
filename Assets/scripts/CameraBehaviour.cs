
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public bool zoom_position;
    float y_change = 1.5f;
    float z_change = -2f;
    GameObject MainCamera;
    new Camera camera;
    // Use this for initialization
    void Start () {
        zoom_position = false;
        MainCamera = GameObject.Find("Main Camera");
        camera = MainCamera.GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100))
            {
                if(hit.collider.tag == "body")
                {
                    y_change = -y_change;
                    z_change = -z_change;
                    camera.transform.localPosition = new Vector3(camera.transform.localPosition.x, camera.transform.localPosition.y+y_change, camera.transform.localPosition.z+z_change);
                }
            }
        }
	}
}
