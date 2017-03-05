using UnityEngine;
using System.Collections;

public class StartTrail : MonoBehaviour {
	public TrailRenderer trail;
	// Use this for initialization
	void Start () {
		trail.sortingLayerName = "Background";
		trail.sortingOrder = 2;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
