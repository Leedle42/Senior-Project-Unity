using UnityEngine;
using System.Collections;

public static class GameVariables {
	public static Vector3 checkpoint;
	public static Quaternion checkpointRot;
	//things for player
	public static float verticalRotation;
	public static float verticalVelocity;
	public static float forwardSpeed;
	public static float sideSpeed;
	public static float sprintSpeed;
	// player platform colliding
	public static bool collidingZ;
	public static bool wasStandingZ;
	public static bool collidingX;
	public static bool wasStandingX;
	public static bool fellFromRotate;
	public static GameObject lastCollide;

	public static bool paused;
	public static bool resume;
	public static bool respawn = false;
	public static bool died = false;
	public static bool deathSound = false;

	public static int deaths = 0;
	public static int level = 0;
}