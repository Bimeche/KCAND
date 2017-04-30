using UnityEngine;
using System.Collections;

public class Paint : MonoBehaviour {
	public Camera cam;
	private Collider coll;
	Texture2D tex;
	void Start() {
		cam = Camera.main;
		coll = GetComponent<Collider>();
	}

	void OnCollisionEnter(Collision collision) {
		RaycastHit hit;

	}
	void Update() {
		if (!Input.GetMouseButton(0))
			return;
		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
			return;
		
		Renderer rend = hit.transform.GetComponent<Renderer>();
		MeshCollider meshCollider = hit.collider as MeshCollider;
		if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
			return;
		
		tex = rend.material.mainTexture as Texture2D;
		Vector2 pixelUV = hit.textureCoord;

		pixelUV.x *= tex.width;
		pixelUV.y *= tex.height;
		tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.white);

		tex.Apply();
		Debug.Log("Drawing");



	}

}
