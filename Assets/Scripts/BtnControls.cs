

using UnityEngine;
using System.Collections;

public class BtnControls : MonoBehaviour {

	public GameObject exitMenu, optionsMenu, playBtn, optionsBtn, exitBtn, pauseScreen, Death_Overlay, DeathMenu,
	Death_Text, Level_Text, SprintImage;
	public AudioClip click;
	private AudioSource clickSound;

	void Awake () {
		clickSound = this.GetComponent<AudioSource> ();
		exitMenu.SetActive (false);
		optionsMenu.SetActive (false);
		pauseScreen.SetActive (false);
	}

	public void StartGame(){
		clickSound.PlayOneShot(click);
		Application.LoadLevel(1);
		GameVariables.sprintSpeed = 1;
		GameVariables.deaths = 0;
		GameVariables.respawn = false;
		GameVariables.died = false;
		YouWin.win = false;
	}
	
	public void ExitMenuShow(){
		clickSound.PlayOneShot(click);
		exitMenu.SetActive (true);
		playBtn.SetActive (false);
		optionsBtn.SetActive (false);
		exitBtn.SetActive (false);
	}
	public void ExitMenuHide(){
		clickSound.PlayOneShot(click);
		exitMenu.SetActive (false);
		playBtn.SetActive (true);
		optionsBtn.SetActive (true);
		exitBtn.SetActive (true);
	}
	public void ExitGame(){
		clickSound.PlayOneShot(click);
		Application.Quit ();
	}

	public void OptMenuShow(){
		clickSound.PlayOneShot(click);
		optionsMenu.SetActive (true);
		playBtn.SetActive (false);
		optionsBtn.SetActive (false);
		exitBtn.SetActive (false);
	}
	public void OptMenuHide(){
		clickSound.PlayOneShot(click);
		optionsMenu.SetActive (false);
		playBtn.SetActive (true);
		optionsBtn.SetActive (true);
		exitBtn.SetActive (true);
	}
	
	public void ResumeGame(){
		clickSound.PlayOneShot(click);
		GameVariables.paused = false;
		GameVariables.resume = true;
		pauseScreen.SetActive (false);
	}
	public void ExitToMainMenu(){
		clickSound.PlayOneShot(click);
		Application.LoadLevel(0);
	}
	public void Respawn(){
		clickSound.PlayOneShot(click);
		GameVariables.respawn = true;
		GameVariables.died = false;
		DeathMenu.SetActive (false);
		Death_Overlay.SetActive (false);
		Death_Text.SetActive (true);
		Level_Text.SetActive (true);
		SprintImage.SetActive (true);
	}
}















