using UnityEngine;
using System.Collections;

public class DestroyShip : MonoBehaviour {

	// Use this for initialization
	public void DestroyObject()
	{
		this.gameObject.transform.parent.gameObject.SetActive (false);
		Destroy (this.gameObject.transform.parent.gameObject, 0.2f);

	}
}
