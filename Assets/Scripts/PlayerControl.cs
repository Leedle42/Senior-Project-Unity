﻿using UnityEngine;
using System.Collections;


public class PlayerControl : MonoBehaviour {
	//limiting variables
	public float movementSpeed = 1.0f;
	public float mouseSensitivity = 4.0f;
	public float jumpSpeed = 20.0f;
	public float upDownRange = 70.0f;
	//Non Public
	int gravityReset = 0;




	CharacterController characterController;
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		characterController = GetComponent<CharacterController>();
		//Value Givers
		GameVariables.verticalRotation = 0;
		GameVariables.sprintSpeed = 1;
	}
	
	// Update is called once per frame
	void Update () {
		//Vertical Rotation
		GameVariables.verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		GameVariables.verticalRotation = Mathf.Clamp (GameVariables.verticalRotation, -upDownRange, upDownRange);
		Camera.main.transform.localRotation = Quaternion.Euler(GameVariables.verticalRotation, 0, 0);

		//Movement
		if (characterController.isGrounded) {
			GameVariables.forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed * GameVariables.sprintSpeed;
			GameVariables.sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed * GameVariables.sprintSpeed;
			//Horizontal Rotation
			float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
			transform.Rotate(0, rotLeftRight, 0);
		}
		//Sprinting
		if (Input.GetButton ("Sprint") && characterController.isGrounded && Input.GetAxis("Vertical")>0) {
			GameVariables.sprintSpeed += ((Mathf.Pow (GameVariables.sprintSpeed, 5/3))/2) * Time.deltaTime;
			GameVariables.sprintSpeed = Mathf.Clamp (GameVariables.sprintSpeed, 0, 5);
		}
		//Stop Sprinting
		if ((!Input.GetButton("Sprint") && characterController.isGrounded)|| (characterController.isGrounded && Input.GetAxis("Vertical")==0)) {
			GameVariables.sprintSpeed = 1;
		}
		//Jumping
		if (characterController.isGrounded && Input.GetButtonDown ("Jump")) {
			GameVariables.verticalVelocity = jumpSpeed;
		}
		Vector3 speed = new Vector3(GameVariables.sideSpeed, GameVariables.verticalVelocity, GameVariables.forwardSpeed);

		speed = transform.rotation * speed;

		characterController.Move( speed * Time.deltaTime );

		// Gravity
		if (characterController.isGrounded && gravityReset == 0) {
			gravityReset = 1;
			GameVariables.verticalVelocity = -0.5f;
		}
		if (!characterController.isGrounded) {
			GameVariables.verticalVelocity += Physics.gravity.y * Time.deltaTime;
			gravityReset = 0;
		}
		//Debug.Log (GameVariables.sprintSpeed);
	}
	void OnTriggerStay (Collider collider) {
		if (collider.gameObject.name == "FloatingIsland") {
			GameVariables.collidingZ = false;
			//print ("works");
		}
	}
}

