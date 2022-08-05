using UnityEditor;
using UnityEngine;
using System.Collections;

public class Help : EditorWindow {
	[MenuItem("Tools/AnBytes/APE Help")]
	public static void ShowHelp() {
		Application.OpenURL(Application.dataPath + "/AdvancedParticleEffects/Editor/AnBytes/doc/index.html");
	}
}
