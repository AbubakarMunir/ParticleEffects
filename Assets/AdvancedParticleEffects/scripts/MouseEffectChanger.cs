using UnityEngine;
using System.Collections;

public class MouseEffectChanger : MonoBehaviour {
	
	public GameObject effect1, effect2, effect3;
	
	void OnGUI() {
		GUILayout.Space(20.0f);
		GUILayout.BeginHorizontal();
		if(GUILayout.Button("Bubbles")) {
			effect2.active = false;	
			effect3.active = false;
			effect1.active = true;
		}
		
		if(GUILayout.Button("Smoke")) {
			effect1.active = false;	
			effect3.active = false;
			effect2.active = true;
		}
		
		if(GUILayout.Button("Sparks")) {
			effect1.active = false;	
			effect2.active = false;
			effect3.active = true;
		}
		GUILayout.EndHorizontal();
	}
}
