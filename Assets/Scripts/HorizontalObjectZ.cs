using UnityEngine;
using System.Collections;

public class HorizontalObjectZ : MonoBehaviour {
	public float horizontalVelocity = 2f;
	public float direction = 1;
	float timePassed = 0;
	int moving = 1;
	// Use this for initialization
	void Start () {
		//GameVariables.collidingZ = false;
	}

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * horizontalVelocity * Time.deltaTime * direction * moving, Space.World);
		if (timePassed <= 3) {
			moving = 1;
		}

		if (timePassed > 3) {
			moving = 0;
		}

		if (timePassed >= 10) {
			direction = direction * -1;
			timePassed = 0;
		}

		timePassed += 1.0f * Time.deltaTime;
	
		if (GameVariables.collidingZ == true) {
			GameObject.Find("Player").transform.Translate (Vector3.forward * horizontalVelocity * Time.deltaTime * direction * moving, Space.World);
		}
	}
	void OnTriggerStay (Collider collider) {
		if (collider.gameObject.name == "Player") {
			//GameVariables.collidingZ = true;
			//print ("works");
		}

	}
}