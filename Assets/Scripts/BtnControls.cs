using UnityEngine;
using System.Collections;

public class BtnControls : MonoBehaviour {

	public GameObject exitMenu, optionsMenu, playBtn, optionsBtn, exitBtn, pauseScreen;

	void Awake(){
		exitMenu.SetActive (false);
		optionsMenu.SetActive (false);
		pauseScreen.SetActive (false);
	}

	public void StartGame(){
		Application.LoadLevel(0);
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
		Application.LoadLevel(1);
	}
}















