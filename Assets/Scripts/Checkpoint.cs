using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.name == "Player") {
			GameVariables.checkpoint=transform.position;
		}
	}
}