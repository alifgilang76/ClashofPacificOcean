using UnityEngine;
using System.Collections;

public class ShipSpawnSound : MonoBehaviour {
	 AudioSource Bell;
	//public AudioClip bell;
	// Use this for initialization
	void Start () {
		AudioSource[] allSources = this.GetComponents<AudioSource> ();
		if (this.gameObject.name == "Iowa(Clone)" || this.gameObject.name == "Baltimore(Clone)" ) {
			Bell = allSources [0];
			Bell.Play();
			Debug.Log ("bisa");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
