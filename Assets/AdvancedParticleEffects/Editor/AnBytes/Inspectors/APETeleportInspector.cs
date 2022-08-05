using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(APETeleport))]
public class APETeleportInspector : Editor {
	
	private string[] options = {"Start", "End"};
	APETeleport control;
	
	public override void OnInspectorGUI() {
		base.OnInspectorGUI();
		control = (APETeleport)target;
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PrefixLabel("Select type:");
		control.select_type = EditorGUILayout.Popup(control.select_type, options);
		EditorGUILayout.EndHorizontal();
		
		if (control.select_type == 0) {
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel("Target ID:");
			control.targetID = EditorGUILayout.IntField(control.targetID);
			EditorGUILayout.EndHorizontal();
		}
		
		if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
	}
	
	/*void OnDestroy() {
		Debug.Log("Script was destroyed");
	}*/
}
