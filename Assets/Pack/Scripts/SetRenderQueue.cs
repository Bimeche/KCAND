/*
	You must to assign this script to the mesh that you want hide.
	Please see the capture example /Tutorials_and_Info/mesh_can_be_hidden.png

	To get it works, you need add to the camera (with xray effect) the "Over" prefab, it is on Pack/Mask. Basically is a plane mesh circle with "DepthMat" material.
	In this project, the camera with xray effect is associated to the bullets.
	Please see the capture example /Tutorials_and_Info/Over_Prefab.png
*/

using UnityEngine;

[AddComponentMenu("Rendering/SetRenderQueue")]

public class SetRenderQueue : MonoBehaviour {
	
	[SerializeField]
	protected int[] m_queues = new int[]{3000}; //No change this value
	
	protected void Awake() {
		Material[] materials = GetComponent<Renderer>().materials;
		for (int i = 0; i < materials.Length && i < m_queues.Length; ++i) {
			materials[i].renderQueue = m_queues[i];
		}
	}
}