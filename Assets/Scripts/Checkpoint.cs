using UnityEngine;
using System.Collections;



public class Checkpoint : MonoBehaviour {

	public float respawnDirection = 0;

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.name == "Player") {
			GameVariables.checkpoint=transform.position;
			GameVariables.checkpointRot = Quaternion.Euler(0, respawnDirection, 0);

		}
	}
}