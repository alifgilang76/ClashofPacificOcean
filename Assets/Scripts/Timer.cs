using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int timeLeft = 72000;
    public Text countdownText;
	public GameObject gameover, finalstate, AllyPort, EnemyPort;
	public int AllyPortHP, EnemyPortHP;
    // Use this for initialization
    void Start()
    {
        StartCoroutine("LoseTime");
    }

    // Update is called once per frame
    void Update()
    {
		int minutes = Mathf.FloorToInt(timeLeft / 60F);
		int seconds = Mathf.FloorToInt(timeLeft - minutes * 60);
		string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        countdownText.text = (niceTime);

        if (timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            countdownText.text = "Times Up!";
			AllyPortHP = AllyPort.GetComponent<PortHealth> ().health;
			EnemyPortHP = EnemyPort.GetComponent<PortHealth> ().health;
			if (EnemyPortHP < AllyPortHP) {
				gameover.SetActive (true);
				finalstate.GetComponent<Text> ().text = "Kalah!\nWaktu Habis, Markas mu berhasil dihancurkan";
				Time.timeScale = 0;
			} else if (AllyPortHP < EnemyPortHP) {
				gameover.SetActive (true);
				finalstate.GetComponent<Text> ().text = "Menang!\nWaktu habis, Markas musuh berhasil dihancurkan";
				Time.timeScale = 0;
			}
        }
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
