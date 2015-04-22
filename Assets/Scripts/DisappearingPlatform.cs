using UnityEngine;
using System.Collections;

public class DisappearingPlatform : MonoBehaviour {
	public float vanishTime = 5;
	public float appearTime = 7;
	float timer = 0;
	bool disappear = false;
	private BoxCollider boxCollider;
	private MeshRenderer meshRenderer;
	// Use this for initialization
	void Start () {
		boxCollider = GetComponent<BoxCollider>();
		meshRenderer = GetComponent <MeshRenderer>();
	}

	// Update is called once per frame
	void Update () {
		if (disappear == true) {
			//timer
			timer += 1.0f * Time.deltaTime;
			//disappear
			if (timer >= vanishTime && boxCollider.enabled == true){
				meshRenderer.enabled = false;
				boxCollider.enabled = false;
			}
			//re-appear
			if (timer >= appearTime){
				timer = 0;
				meshRenderer.enabled = true;
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
