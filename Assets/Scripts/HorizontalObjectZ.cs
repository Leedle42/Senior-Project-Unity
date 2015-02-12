using UnityEngine;
using System.Collections;

public class HorizontalObjectZ : MonoBehaviour {
	public float horizontalVelocity = 0.2f;
	public float direction = 1;
	float timePassed = 0;
	bool colliding = false;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (timePassed <= 3) {
			transform.Translate(Vector3.forward * horizontalVelocity * Time.deltaTime * direction, Space.World);
		}
		if (timePassed >= 10) {
			direction = direction * -1;
			timePassed = 0;
		}
		timePassed += 1.0f * Time.deltaTime;
	
		if (colliding == true) {
				transform.Find("Player").Translate (Vector3.forward * 2 * Time.deltaTime * direction, Space.World);
		}
	}
}