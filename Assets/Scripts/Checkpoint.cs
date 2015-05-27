using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	// initialize a variable that can be used in the unity inspector
	// to simply change the direction the player respawns at each checkpoint
	public float respawnDirection = 0;
	public AudioClip checkpoint;
	private AudioSource checkpointSound;

	void Start () {
		checkpointSound = this.GetComponent<AudioSource> ();
	}
	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.name == "Player") {
			// set the new respawn position and rotation
			GameVariables.checkpoint=transform.position;
			GameVariables.checkpointRot = Quaternion.Euler(0, respawnDirection, 0);
			checkpointSound.PlayOneShot(checkpoint);
		}
	}
}