using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameVariables.checkpoint = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	if (transform.position.y < -50) {
			transform.position = GameVariables.checkpoint;
			transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
			GameVariables.verticalRotation = 0;
			GameVariables.verticalVelocity = 0;
			GameVariables.sideSpeed = 0;
			GameVariables.forwardSpeed = 0;
		}
	}
}
