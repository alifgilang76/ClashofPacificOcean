using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResGUI : MonoBehaviour {
	public GameObject Reso, PauseMenu, GameOver, AllyPort, EnemyPort, FinalState;
	public int AllyPortHP, EnemyPortHP;
	public Economy GetRes;
	public Text SteelText, FuelText = null;
	public bool isPause = false;

	// Use this for initialization
	void Start () {
		GetRes = Reso.GetComponent<Economy>();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!isPause) {
				PauseMenu.SetActive (true);
				isPause = true;
				Time.timeScale = 0;
			} else if (isPause) {
				PauseMenu.SetActive (false);
				isPause = false;
				Time.timeScale = 1;
			}
		}

		AllyPortHP = AllyPort.GetComponent<PortHealth> ().health;
		EnemyPortHP = EnemyPort.GetComponent<PortHealth> ().health;
		Scene scene = SceneManager.GetActiveScene();
		if (scene.name != "Pengujian")// name of scene
		{
			if (AllyPortHP <= 0) {
				GameOver.SetActive (true);
				FinalState.GetComponent<Text> ().text = "Kalah!\nMarkasmu sudah dihancurkan musuh";
				Time.timeScale = 0;
			} else if (EnemyPortHP <= 0) {
				GameOver.SetActive (true);
				FinalState.GetComponent<Text> ().text = "Menang!\nMarkas musuh berhasil dihancurkan";
				Time.timeScale = 0;
			}
		}
		SteelText.text = System.Convert.ToString (GetRes.SteelRes);
		FuelText.text = System.Convert.ToString (GetRes.FuelRes);
	}
}
