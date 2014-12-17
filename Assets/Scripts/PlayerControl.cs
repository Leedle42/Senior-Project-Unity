using UnityEngine;
using System.Collections;


public class PlayerControl : MonoBehaviour {
	//limiting variables
	public float movementSpeed = 7.0f;
	public float mouseSensitivity = 4.0f;
	public float jumpSpeed = 20.0f;
	public float upDownRange = 60.0f;
	//Initializers
	float verticalRotation = 0;
	float verticalVelocity = 0;
	float playerY = 3;



	CharacterController characterController;
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		characterController = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {

		//Rotation
		float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate(0, rotLeftRight, 0);

		verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp (verticalRotation, -upDownRange, upDownRange);
		Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);


		//Movement
		float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
		float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

		if (characterController.isGrounded && Input.GetButtonDown ("Jump")) {
			verticalVelocity = jumpSpeed;
		}
		if (!characterController.isGrounded) {
				verticalVelocity += Physics.gravity.y * Time.deltaTime;
		}
		Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

		speed = transform.rotation * speed;

		characterController.Move( speed * Time.deltaTime );

		//Respawn
		playerY = characterController.transform.position.y;
		if (playerY < -50) {
			characterController.transform.position = new Vector3(0,3,0);
			transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
			Camera.main.transform.rotation = Quaternion.AngleAxis(0, Vector3.);

		}
	}
}
