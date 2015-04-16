using UnityEngine;
using System.Collections;

public class DisappearingPlatform : MonoBehaviour {
	public float vanishTime = 5;
	public float appearTime = 7;
	float timer = 0;
	bool disappear = false;
	private BoxCollider boxCollider;
	// Use this for initialization
	void Start () {
		boxCollider = GetComponent<BoxCollider>();
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (boxCollider.enabled);
		if (disappear == true) {
			//timer
			timer += 1.0f * Time.deltaTime;
			//disappear
			if (timer >= vanishTime && boxCollider.enabled == true){
				boxCollider.enabled = false;
			}
			//re-appear
			if (timer >= appearTime){
				timer = 0;
				boxCollider.enabled = true;
				disappear = false;
			}

		}
	}
	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.name == "Player") {
			disappear = true;
		}
	}
}
