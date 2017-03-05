using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FactoryHealth : MonoBehaviour {
	private int health, maxHealth;
	private Image healthBar;
	// Use this for initialization
	void Start () {
		health = 50000;
		maxHealth = 50000;
		healthBar = transform.FindChild ("CanvasUnit").FindChild ("HealthBG").FindChild ("Health").GetComponent<Image> ();
	}

	// Update is called once per frame
	//	void Update () {
	//		if (health <= 0) {
	//			//this.GetComponent<Animation> ().Play ("Sink");
	//			transform.FindChild("pCube24").GetComponent<Animation>().Play();
	//		}
	//	}

	public void Hit(int damage)
	{
		health -= damage;
		healthBar.fillAmount = (float)health/(float)maxHealth;
		Debug.Log (health);
	}
}
