using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour {

	public GameObject StartBtn, SubMenu, AboutPanel, ProloguePanel, BattleBtn;
	public Text PrologueText;
	public string PrologueText_tmp;
	public float letterPause;

	void Start(){
		PrologueText_tmp = PrologueText.text;
		PrologueText.text = "";
	}

	public void ChooseMenu (Button btn){
		switch (btn.name) {
		case "Start Button":
			StartBtn.SetActive (false);
			SubMenu.SetActive (true);
			break;
		case "New Game":
			ProloguePanel.SetActive (true);
			StartCoroutine ("TypeText");

			break;
		case "Battle Button":
			SceneManager.LoadSceneAsync ("Map", LoadSceneMode.Single);
			break;
		case "About Game":
			AboutPanel.SetActive (true);
			SubMenu.SetActive (false);
			break;
		case "Exit About":
			AboutPanel.SetActive (false);
			SubMenu.SetActive (true);
			break;
		case "Exit":
			Application.Quit ();
			break;
		}
	}

	IEnumerator TypeText () {
		foreach (char letter in PrologueText_tmp.ToCharArray()) {
			PrologueText.text += letter;
			yield return 0;
			yield return new WaitForSeconds (letterPause);
		}
		BattleBtn.SetActive (true);
	}
}
