using UnityEngine;
using System.Collections;

public class MoveToCursor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {	
			Vector3 scanPos = transform.position;
			Vector3 screenPoint = Camera.main.WorldToScreenPoint(scanPos);
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
			transform.position = curPosition;
	}
}
