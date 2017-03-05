using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BuildProgress : MonoBehaviour {

	public GameObject progress;
	public float durationReq;
	public Slider progressSlider;
	public bool doProgressRun;
	public float fltBuildTime = 0f;
	public float fltElapsedTime = 0f;
	// Use this for initialization

	void start()
	{
		progressSlider = progress.GetComponent<Slider> ();
	}
	public IEnumerator doProgress () {
		doProgressRun = false;
		for (int p = 0; p <= 3; p++) {
			if (p < 4) {
				yield return new WaitForSeconds (1f);
			}
			progressSlider.value++;
		}
		progressSlider.value = 0;
		GameObject.Find ("Canvas/PanelProgress").SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (doProgressRun) {
			fltElapsedTime += Time.deltaTime;

			if (fltElapsedTime >= fltBuildTime) {
				doProgressRun = false;
				fltBuildTime = 0f;
				fltElapsedTime = 0f;
				progressSlider.value = 0;
				this.GetComponent<AudioSource> ().Play ();
				GameObject.Find ("Canvas/PanelProgress").SetActive (false);

			} else {
				progressSlider.value = fltElapsedTime;
			}
			//StartCoroutine (doProgress ());
		}
	}
}
