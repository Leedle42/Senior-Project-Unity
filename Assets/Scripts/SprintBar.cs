using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SprintBar : MonoBehaviour {

	public GameObject SprintImage;
	public Texture SprintBar0;
	public Texture SprintBar2;
	public Texture SprintBar3;
	public Texture SprintBar4;
	public Texture SprintBar5;
	public Texture SprintBar6;
	public Texture SprintBar7;
	public Texture SprintBar8;
	public Texture SprintBar9;
	public Texture SprintBar10;
	//private RawImage SprintBar0;
	//private RawImage SprintBar2;
	//private RawImage SprintBar3;
	//private RawImage SprintBar4;
	//private RawImage SprintBar5;
	//private RawImage SprintBar6;
	//private RawImage SprintBar7;
	//private RawImage SprintBar8;
	//private RawImage SprintBar9;
	private RawImage img;
	
	// Use this for initialization
	public void Start () {
		img = (RawImage)SprintImage.GetComponent<RawImage>();

	}
	
	// Update is called once per frame
	public void Update () {
		if (Mathf.Abs(Input.GetAxis ("Vertical")) == 0 && Mathf.Abs (Input.GetAxis ("Horizontal")) == 0) {
			//Default bar
			img.texture = (Texture)SprintBar0;
		}
		if (Mathf.Abs(Input.GetAxis ("Vertical")) == 1 || Mathf.Abs(Input.GetAxis ("Horizontal")) == 1) {
			//SprintBar2
			img.texture = (Texture)SprintBar2;
		}
		if (GameVariables.sprintSpeed > 1.0 && GameVariables.sprintSpeed <= 1.5) {
			//SprintBar3
			img.texture = (Texture)SprintBar3;
		}
		if (GameVariables.sprintSpeed > 1.5 && GameVariables.sprintSpeed <= 2.0) {
			//SprintBar4
			img.texture = (Texture)SprintBar4;
		}
		if (GameVariables.sprintSpeed > 2.0 && GameVariables.sprintSpeed <= 2.5) {
			//SprintBar5
			img.texture = (Texture)SprintBar5;
		}
		if (GameVariables.sprintSpeed > 2.5 && GameVariables.sprintSpeed <= 3.0) {
			//SprintBar6
			img.texture = (Texture)SprintBar6;
		}
		if (GameVariables.sprintSpeed > 3.0 && GameVariables.sprintSpeed <= 3.5) {
			//SprintBar7
			img.texture = (Texture)SprintBar7;
		}
		if (GameVariables.sprintSpeed > 3.5 && GameVariables.sprintSpeed <= 4.0) {
			//SprintBar8
			img.texture = (Texture)SprintBar8;
		}
		if (GameVariables.sprintSpeed > 4.0 && GameVariables.sprintSpeed <= 4.5) {
			//SprintBar9
			img.texture = (Texture)SprintBar9;
		}
		if (GameVariables.sprintSpeed > 4.5 && GameVariables.sprintSpeed <= 5.0) {
			//SprintBar10
			img.texture = (Texture)SprintBar10;
		}
	}
}
