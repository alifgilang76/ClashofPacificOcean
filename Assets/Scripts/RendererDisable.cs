using UnityEngine;
using System.Collections;

public class RendererDisable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().enabled = false;
	}
	

}
