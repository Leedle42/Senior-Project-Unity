using UnityEngine;
using System.Collections;

public class HorizontalObject : MonoBehaviour {
	float horizontalVelocity = 0.2f;
	float timePassed = 3.14159f / 10;
	public float horizontalVelocityO = 0.2f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		timePassed += 0.8f * Time.deltaTime;
		if (timePassed >= 3) {
			horizontalVelocity = 0;
		}
		if (timePassed >= 5) {
			horizontalVelocity = horizontalVelocityO * -1;
			horizontalVelocityO = horizontalVelocity;
			timePassed = 0;
		}
		Vector3 speed = new Vector3(horizontalVelocity, 0, 0);
		transform.position += speed;
		//horizontalVelocity = Mathf.Cos (timePassed * 5) * 0.5f;
		//Vector3 speed = new Vector3 (horizontalVelocity, 0, 0);
		//speed = transform.rotation * speed;
		//transform.position += speed;
		Debug.Log (timePassed);

	}
}
