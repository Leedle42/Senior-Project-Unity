

using UnityEngine;
using System.Collections;

public class BtnControls : MonoBehaviour {

	public GameObject exitMenu, optionsMenu, playBtn, optionsBtn, exitBtn, pauseScreen, Death_Overlay, DeathMenu,
	Death_Text, Level_Text, SprintImage;

	void Awake () {
		exitMenu.SetActive (false);
		optionsMenu.SetActive (false);
		pauseScreen.SetActive (false);
	}

	public void StartGame(){
		Application.LoadLevel(1);
		GameVariables.deaths = 0;
		GameVariables.respawn = false;
		GameVariables.died = false;
	}
	
	public void ExitMenuShow(){
		exitMenu.SetActive (true);
		playBtn.SetActive (false);
		optionsBtn.SetActive (false);
		exitBtn.SetActive (false);
	}
	public void ExitMenuHide(){
		exitMenu.SetActive (false);
		playBtn.SetActive (true);
		optionsBtn.SetActive (true);
		exitBtn.SetActive (true);
	}
	public void ExitGame(){
		Application.Quit ();
	}

	public void OptMenuShow(){
		optionsMenu.SetActive (true);
		playBtn.SetActive (false);
		optionsBtn.SetActive (false);
		exitBtn.SetActive (false);
	}
	public void OptMenuHide(){
		optionsMenu.SetActive (false);
		playBtn.SetActive (true);
		optionsBtn.SetActive (true);
		exitBtn.SetActive (true);
	}
	
	public void ResumeGame(){
		GameVariables.paused = false;
		GameVariables.resume = true;
		pauseScreen.SetActive (false);
	}
	public void ExitToMainMenu(){
		Application.LoadLevel(0);
	}
	public void Respawn(){
		GameVariables.respawn = true;
		GameVariables.died = false;
		DeathMenu.SetActive (false);
		Death_Overlay.SetActive (false);
		Death_Text.SetActive (true);
		Level_Text.SetActive (true);
		SprintImage.SetActive (true);
	}
}















