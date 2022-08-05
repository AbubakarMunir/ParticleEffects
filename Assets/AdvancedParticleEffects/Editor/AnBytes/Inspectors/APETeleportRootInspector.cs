using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;


[CustomEditor(typeof(APETeleportRoot))]
public class APETeleportRootInspector : Editor {
		
	void OnSceneGUI() {
		Event e = Event.current;
		if (e.type == EventType.MouseDown) {
			Ray ray = HandleUtility.GUIPointToWorldRay(e.mousePosition);
			RaycastHit[] hits = Physics.RaycastAll (ray.origin,ray.direction,300);
			teleport_add(hits);
		}
	}
	
	void teleport_add(RaycastHit[] cur_hits) {
		for (int i = 0; i < cur_hits.Length; i++) {
			RaycastHit hit = cur_hits[i];	
			
			GameObject teleport_start_prefab = Resources.Load("Teleport/Prefabs/Teleport") as GameObject;
			GameObject teleport_start = (GameObject)Instantiate(teleport_start_prefab);
			
			teleport_start.AddComponent<SphereCollider>();
			SphereCollider tmp = teleport_start.GetComponent("SphereCollider") as SphereCollider;
			tmp.isTrigger = true;
			tmp.radius = 1.5f;
			int curID = SaveInfo();
			
			teleport_start.AddComponent<APETeleport>();
			teleport_start.transform.parent = (Selection.activeObject as GameObject).transform;
			teleport_start.name = "Teleport";
			
			APETeleport tmp2 = teleport_start.GetComponent("APETeleport") as APETeleport;
			tmp2.teleportID = curID;
			teleport_start.transform.position = hit.point;
			teleport_start.tag = "TeleportObj";
		}
	}
	
	int SaveInfo() {
		string path = Application.dataPath+"/AdvancedParticleEffects/Resources/APEDB/";
		int curID = -1;
		if ( !File.Exists(path+"tc.db") ) {
			using (StreamWriter writer = new StreamWriter(path+"tc.db")) {
	    	writer.Write("1");
			}
			curID = 0;
		}
		else {
			string count;
			int icount;
			using (StreamReader reader = new StreamReader(path+"tc.db")) {
	    		count = reader.ReadLine();
			}
			icount = int.Parse(count);
			using (StreamWriter writer = new StreamWriter(path+"tc.db")) {
	    	writer.Write((icount+1).ToString());
			}
			curID = icount;
		}
		
		using (StreamWriter writer = new StreamWriter(path+"teleports.db", true)) {
	    	writer.WriteLine(curID+": Start");
		}
		return curID;
	}
}
