using UnityEngine;
using System.Collections;

public class APETeleport : MonoBehaviour {
	
	[HideInInspector]
	public int select_type = 0;
	[HideInInspector]
	public int targetID = -1;
	
	public int teleportID = -1;
	private GameObject[] all_teleports;
	
	private GameObject atoms_prefab;
	private GameObject atoms;
	
	void Start() {
		all_teleports = GameObject.FindGameObjectsWithTag("TeleportObj");
		//atoms_prefab = Resources.Load("Teleport/Prefabs/Atoms2") as GameObject;
	}
	void OnTriggerEnter(Collider other) {
		if (targetID > -1) {
			for (int i = 0; i < all_teleports.Length; i++) {
				APETeleport tmp = all_teleports[i].GetComponent("APETeleport") as APETeleport;
				if (tmp.teleportID == targetID) {					
					other.gameObject.transform.position = new Vector3(all_teleports[i].transform.position.x, all_teleports[i].transform.position.y + 2.0f, all_teleports[i].transform.position.z);
					//other.gameObject.transform.GetChildCount = false;
					/*atoms = (GameObject)Instantiate(atoms_prefab);
					atoms.transform.position = other.gameObject.transform.position;
					
					MeshFilter tmpm = atoms.GetComponent<MeshFilter>();
					tmpm = other.gameObject.GetComponent<MeshFilter>();*/
				}
			}
		}
	}
}
