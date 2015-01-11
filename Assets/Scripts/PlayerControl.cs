using UnityEngine;
using System.Collections;


public class PlayerControl : MonoBehaviour {
	//limiting variables
	public float movementSpeed = 7.0f;
	public float mouseSensitivity = 4.0f;
	public float jumpSpeed = 20.0f;
	public float upDownRange = 70.0f;
	//Non Public
	float verticalVelocity = 0;
	float forwardSpeed = 0;
	float sideSpeed = 0;


	CharacterController characterController;
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		characterController = GetComponent<CharacterController>();
		//Value Givers
		GameVariables.verticalRotation = 0;
		float verticalVelocity = 0;
		float forwardSpeed = 0;
		float sideSpeed = 0;

	}
	
	// Update is called once per frame
	void Update () {

		//Vertical Rotation
		GameVariables.verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		GameVariables.verticalRotation = Mathf.Clamp (GameVariables.verticalRotation, -upDownRange, upDownRange);
		Camera.main.transform.localRotation = Quaternion.Euler(GameVariables.verticalRotation, 0, 0);

		//Movement
		if (characterController.isGrounded) {
			forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed;
			sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed;
			//Horizontal Rotation
			float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
			transform.Rotate(0, rotLeftRight, 0);
		}
		if (characterController.isGrounded && Input.GetButtonDown ("Jump")) {
			verticalVelocity = jumpSpeed;
		}
		Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

		speed = transform.rotation * speed;

		characterController.Move( speed * Time.deltaTime );

		// Gravity
		if (!characterController.isGrounded) {
			verticalVelocity += Physics.gravity.y * Time.deltaTime;
		}

		Debug.Log (GameVariables.checkpoint);



		}
	}

