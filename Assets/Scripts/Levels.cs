using UnityEngine;
using System.Collections;

public class Levels : MonoBehaviour {
	public int levelnmbr;

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.name == "Player") {
		GameVariables.level = levelnmbr;
		}
	}
}