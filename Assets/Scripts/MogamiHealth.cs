using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MogamiHealth : MonoBehaviour {
	private int health, maxHealth;
	private Image healthBar;

	//private Animator animator = null;
	// Use this for initialization
	void Start () {
		
		health = 39100;
		maxHealth = 39100;
		healthBar = transform.FindChild ("CanvasUnit").FindChild ("HealthBG").FindChild ("Health").GetComponent<Image> ();
	}
	
	// Update is called once per frame

	void Update () {
		//Debug.Log (health);
		//animator = this.gameObject.GetComponent<Animator> ();
		if (health <= 0) {
			//this.GetComponent<Animation> ().Play ("Sink");
			transform.FindChild("pCube24").GetComponent<Animation>().Play();
		}
	}


	public void Hit(int damage)
	{
		health -= damage;
		healthBar.fillAmount = (float)health/(float)maxHealth;
	}
}
