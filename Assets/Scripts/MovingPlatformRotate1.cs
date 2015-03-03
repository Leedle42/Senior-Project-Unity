using UnityEngine;
using System.Collections;

public class MovingPlatformRotate1 : MonoBehaviour {
	public float rotateSpeed = 20;
	public bool colliding = false;
	public Transform platform;
	Vector3 launchSpeed;
	// Use this for initialization
	void Start()
	{
		// Remove Center Point From Parent
		//transform.DetachChildren ();
		// Set variable tracking platform's transform
		platform = GameObject.Find ("MovingPlatform-rotate1").transform;
	}

	void Update () {
		Debug.DrawRay (transform.position, Vector3.up * 10, Color.green);
		Rotate ();
		if (GameVariables.wasStandingR == true) {

			GameObject.Find("Player").transform.Translate (launchSpeed * Time.deltaTime, Space.World);
		}
	}

	void Rotate(){
		if (colliding == true) {
			transform.RotateAround (GameObject.Find ("rotate1Center").transform.position, new Vector3 (0, 1, 0), rotateSpeed * Time.deltaTime); // (1 is left) (-1 is right)
		}
	}
	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject.name == ("Player")) {
			colliding = true;
		}
	}
	void OnTriggerExit (Collider collider) {
		if (collider.gameObject.name == ("Player")){
			transform.DetachChildren();
			GameVariables.wasStandingR = true;
			// set the velocity vector
			launchSpeed = platform.TransformDirection (Vector3.up) *10;

		}
	}

}