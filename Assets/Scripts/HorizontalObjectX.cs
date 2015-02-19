using UnityEngine;
using System.Collections;

public class HorizontalObjectX : MonoBehaviour {
	public float horizontalVelocity = 2f;
	public int direction = 1;
	int directionOnLeave = 1;
	float timePassed = 0;
	int moving = 1;
	bool standing = false;
	// Use this for initialization
	void Start () {
		GameVariables.collidingX = false;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * horizontalVelocity * Time.deltaTime * direction * moving, Space.World);
		// moving
		if (timePassed <= 3) {
			moving = 1;
		}
		// stop
		if (timePassed > 3) {
			moving = 0;
		}
		//turn around
		if (timePassed >= 5) {
			direction = direction * -1;
			timePassed = 0;
		}
		// timer
		timePassed += 1.0f * Time.deltaTime;
		// move player
		if (GameVariables.collidingX == true && standing == true) {
			GameObject.Find("Player").transform.Translate (Vector3.left * horizontalVelocity * Time.deltaTime * direction * moving, Space.World);
		}
		if (GameVariables.collidingX == true && standing == false && GameVariables.wasStandingX == true) {
			GameObject.Find("Player").transform.Translate (Vector3.left * horizontalVelocity * Time.deltaTime * directionOnLeave , Space.World);
		}
	}
	//player stands on platform
	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject.name == "Player") {
			GameVariables.collidingX = true;
			GameVariables.wasStandingX = true;
			standing = true;
			print ("works");

		}
	}
	//player leaves platform
	void OnTriggerExit (Collider collider) {
		if (collider.gameObject.name == "Player") {
			if (moving == 0){
				directionOnLeave = 0;
			}
			else {
				directionOnLeave = direction;
			}
			standing = false;
			print ("works");
		}
	}
}
