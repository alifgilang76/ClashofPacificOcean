using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour {

	public ResGUI getResGUI;
	public GameObject PauseMenu;

	public void Confirm(Button YesNo){
		switch (YesNo.name) {
		case ("Yes"):
			Application.Quit();
			break;
		case ("No"):
			PauseMenu.SetActive (false);
			getResGUI.isPause = false;
			Time.timeScale = 1;
			break;
		}
	}
	public void BackToMainMenu(){
		SceneManager.LoadSceneAsync ("Main_Menu", LoadSceneMode.Single);
		Time.timeScale = 1;
	}

}
