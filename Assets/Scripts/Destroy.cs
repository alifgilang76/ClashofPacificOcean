using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	public void DestroyObject()
	{
		Destroy (this.gameObject.transform.parent.gameObject);
	}
}
