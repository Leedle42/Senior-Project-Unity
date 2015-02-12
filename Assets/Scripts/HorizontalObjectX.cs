using UnityEngine;
using System.Collections;

public class HorizontalObjectX : MonoBehaviour {
	public float horizontalVelocity = 0.2f;
	float timePassed = 0;
	public float direction = 1;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (timePassed <= 3) {
			transform.Translate(Vector3.left * horizontalVelocity * Time.deltaTime * direction, Space.World);
		}
		if (timePassed >= 10) {
			direction = direction * -1;
			timePassed = 0;
		}
		timePassed += 1.0f * Time.deltaTime;

		}

}

