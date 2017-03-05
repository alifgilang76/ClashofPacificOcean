using UnityEngine;
using System.Collections;

public class ActivateHealth : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (this.gameObject.name == "OilRig" || this.gameObject.name == "Factory 1")
		{
			GameObject x = this.gameObject.transform.FindChild ("CanvasUnit").gameObject;
			x.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
