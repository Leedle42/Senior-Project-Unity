using UnityEngine;
using System.Collections;

public class ClockwiseCircleObject : MonoBehaviour {
	float rotateSpeed = 20;

	// Use this for initialization
	void Start()
	{

	}

	void Update () {
	
		Rotate ();
	}

	void Rotate(){
	
		transform.RotateAround(GameObject.Find("rotate1Center").transform.position, new Vector3(0, 1, 0), rotateSpeed * Time.deltaTime); // (1 is left) (-1 is right)
	}


}