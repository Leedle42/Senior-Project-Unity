using UnityEngine;
using System.Collections;

public class YouWin : MonoBehaviour {

	public static bool win = false;
	
	// Update is called once per frame
	void OnTriggerEnter (Collider collider){
		if (collider.gameObject.name == "Player") {
			win = true;
		}
	}
}
