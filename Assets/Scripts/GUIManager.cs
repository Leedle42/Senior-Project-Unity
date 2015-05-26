using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

	//Sprint Bar
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
	private RawImage img;

	//You Win Overlay
	public GameObject You_Win;

	//Level Text
	public GameObject Level_Text;
	Text level;

	//Death Text
	public GameObject Death_Text;
	Text death;

	//Death
	public GameObject DeathOverlay;
	public GameObject Death_Menu;

	// Use this for initialization
	public void Start () {
		You_Win.SetActive (false);
		DeathOverlay.SetActive (false);
		Death_Menu.SetActive (false);
		img = (RawImage)SprintImage.GetComponent<RawImage>();
		level = Level_Text.GetComponent<Text> ();
		level.text = "Level: " + GameVariables.level;
		death = Death_Text.GetComponent<Text> ();
		death.text = "Deaths: " + GameVariables.deaths;
	}
	
	// Update is called once per frame
	public void Update () {
		// Death Screen
		if (GameVariables.died) {
			DeathOverlay.SetActive (true);
			Death_Menu.SetActive (true);
			Death_Text.SetActive (false);
			Level_Text.SetActive (false);
			SprintImage.SetActive (false);
			Time.timeScale = 0f;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
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
		//You Win Screen
		if (YouWin.win) {
			You_Win.SetActive (true);
			Death_Text.SetActive (false);
			Level_Text.SetActive (false);
			SprintImage.SetActive (false);
			Time.timeScale = 0f;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}

		//Death Counter
		death.text = "Deaths: " + GameVariables.deaths;

		//Level update
		level.text = "Level: " + GameVariables.level;
	}
}
