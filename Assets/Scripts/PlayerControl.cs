using UnityEngine;
using System.Collections;


public class PlayerControl : MonoBehaviour {
	//limiting variables
	public float movementSpeed = 1.0f;
	public float mouseSensitivity = 4.0f;
	public float jumpSpeed = 20.0f;
	public float upDownRange = 70.0f;
	//Non Public
	float sprintSpeed = 1;



	CharacterController characterController;
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		characterController = GetComponent<CharacterController>();
		//Value Givers
		GameVariables.verticalRotation = 0;

	}
	
	// Update is called once per frame
	void Update () {
		//Vertical Rotation
		GameVariables.verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		GameVariables.verticalRotation = Mathf.Clamp (GameVariables.verticalRotation, -upDownRange, upDownRange);
		Camera.main.transform.localRotation = Quaternion.Euler(GameVariables.verticalRotation, 0, 0);

		//Movement
		if (characterController.isGrounded) {
			GameVariables.forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed * sprintSpeed;
			GameVariables.sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed * sprintSpeed;
			//Horizontal Rotation
			float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
			transform.Rotate(0, rotLeftRight, 0);
		}
		//Sprinting
		if (Input.GetButton ("Sprint") && characterController.isGrounded && Input.GetAxis("Vertical")>0) {
			sprintSpeed += ((Mathf.Pow (sprintSpeed, 5/3))/2) * Time.deltaTime;
			sprintSpeed = Mathf.Clamp (sprintSpeed, 0, 5);
		}
		//Stop Sprinting
		if ((!Input.GetButton("Sprint") && characterController.isGrounded)|| (characterController.isGrounded && Input.GetAxis("Vertical")==0)) {
			sprintSpeed = 1;
		}
		//Jumping
		if (characterController.isGrounded && Input.GetButtonDown ("Jump")) {
			GameVariables.verticalVelocity = jumpSpeed;
		}
		Vector3 speed = new Vector3(GameVariables.sideSpeed, GameVariables.verticalVelocity, GameVariables.forwardSpeed);

		speed = transform.rotation * speed;

		characterController.Move( speed * Time.deltaTime );

		// Gravity
		if (!characterController.isGrounded) {
			GameVariables.verticalVelocity += Physics.gravity.y * Time.deltaTime;
		}
		Debug.Log (sprintSpeed);

		}
	}

