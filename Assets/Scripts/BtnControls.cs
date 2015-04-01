using UnityEngine;
using System.Collections;

public class BtnControls : MonoBehaviour {

	public GameObject exitMenu, optionsMenu;

	void Awake(){
		exitMenu.SetActive (false);
		optionsMenu.SetActive (false);
	}

	public void StartGame(){
		Application.LoadLevel(0);
	}
	
	public void ExitMenuShow(){
		exitMenu.SetActive (true);
	}
	public void ExitMenuHide(){
		exitMenu.SetActive (false);
	}
	public void ExitGame(){
		Application.Quit ();
	}

	public void OptMenuShow(){
		optionsMenu.SetActive (true);
	}
	public void OptMenuHide(){
		optionsMenu.SetActive (false);
	}
}
