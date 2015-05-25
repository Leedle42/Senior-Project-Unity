using UnityEngine;
using System.Collections;

public class ClockwiseRotate1 : MonoBehaviour {
	public float rotateSpeed = 20;
	public Transform platform;
	public string thisObject = "ClockwiseRotate1";
	public string center = "ClockwiseRotate1Center";
	bool wasStandingR = false;
	public int direction = 1;
	Vector3 launchSpeed;
	// Use this for initialization
	void Start()
	{
		// Remove Center Point From Parent
		transform.DetachChildren ();
		// Set variable tracking platform's transform
		platform = GameObject.Find (thisObject).transform;
		GameVariables.fellFromRotate = false;
	}

	void Update () {
		Rotate ();
		// check if player jumped off
		if (GameVariables.lastCollide.name != thisObject || GameVariables.fellFromRotate == true) {
			wasStandingR = false;
			GameVariables.fellFromRotate = false;
		}
		// launch the player tangent to platform
		if (wasStandingR == true) {

			GameObject.Find("Player").transform.Translate (launchSpeed * Time.deltaTime, Space.World);
		}

	}

	void Rotate(){
		// rotate the platform
		transform.RotateAround (GameObject.Find (center).transform.position, new Vector3 (0, direction, 0), rotateSpeed * Time.deltaTime); // (1 is left) (-1 is right)
	}
	void OnTriggerExit (Collider collider) {
		if (collider.gameObject.name == ("Player")){
			transform.DetachChildren();
			wasStandingR = true;
			// set the velocity vector
			launchSpeed = platform.TransformDirection (Vector3.up) * (rotateSpeed / 3);
		}
	}

}