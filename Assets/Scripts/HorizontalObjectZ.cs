using UnityEngine;
using System.Collections;

public class HorizontalObjectZ : MonoBehaviour {
	public float horizontalVelocity = 2f;
	public int direction = 1;
	public float travelTime = 3;
	public float reverseTime = 5;
	public string thisObject = "MovingPlatformZ1";
	int directionOnLeave = 1;
	public float timePassed = 0;
	int moving = 1;
	bool standing = false;
	Vector3 startPos;
	// Use this for initialization
	void Start () {
		GameVariables.collidingZ = false;
		startPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
	
		transform.Translate(Vector3.forward * horizontalVelocity * Time.deltaTime * direction * moving, Space.World);
		// moving
		if (timePassed <= travelTime) {
			moving = 1;
		}
		// stop
		if (timePassed > travelTime) {
			moving = 0;
		}
		//turn around
		if (timePassed >= reverseTime) {
			if (direction == -1) {
				transform.position = startPos;
			}
			direction = direction * -1;
			timePassed = 0;
		}
		// timer
		timePassed += 1.0f * Time.deltaTime;
		// move player
		if (GameVariables.lastCollide.name == thisObject && standing == true) {
			GameObject.Find("Player").transform.Translate (Vector3.forward * horizontalVelocity * Time.deltaTime * direction * moving, Space.World);
		}
		if (GameVariables.lastCollide.name == thisObject && standing == false) {
			GameObject.Find("Player").transform.Translate (Vector3.forward * horizontalVelocity * Time.deltaTime * directionOnLeave , Space.World);
		}
	}
	//player stands on platform
	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject.name == "Player") {
			standing = true;
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
		}
	}

}