using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameVariables.checkpoint = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		GameVariables.checkpointRot = Quaternion.Euler(0, 180, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -50 && !GameVariables.respawn) {
			GameVariables.died = true;
		}
		if (GameVariables.respawn){
			transform.position = GameVariables.checkpoint;
			transform.rotation = GameVariables.checkpointRot;
			GameVariables.verticalRotation = 0;
			GameVariables.verticalVelocity = 0;
			GameVariables.sideSpeed = 0;
			GameVariables.forwardSpeed = 0;
			// in case fall off of moving platform (reset the velocity)
			GameVariables.fellFromRotate = true;
			GameVariables.collidingZ = false;
			GameVariables.wasStandingZ = false;
			GameVariables.collidingX = false;
			GameVariables.wasStandingX = false;
			GameVariables.lastCollide = GameObject.Find ("FloatingIsland");
			Time.timeScale = 1f;
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			//Add to death counter
			++GameVariables.deaths;
			GameVariables.respawn = false;
		}
	}
}
