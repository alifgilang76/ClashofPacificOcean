using UnityEngine;
using System.Collections;

public class AttackIowa : MonoBehaviour {
	public GameObject bulletPrefab, clone;
	public Transform[] bulletSpawn;
	bool startAttack = false;
	float attackTime = 10f;
	AudioSource ShootSound;
	// Use this for initialization
	public void StartAttack () {
		if (!startAttack) {
			Shoot ();
			startAttack = true;
			attackTime = 10f;
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (startAttack) {
			attackTime -= Time.deltaTime;
			if (attackTime <= 0) {
				Shoot ();
				attackTime = 10f;
			}
		}
			//StartCoroutine (Shoot ());

	}


	public void stopAttack()
	{
		
		startAttack = false;
	}

	void Shoot()
	{
		
		for (var i = 0; i < bulletSpawn.Length; i++) {
			
			Instantiate (bulletPrefab, bulletSpawn [i].position, bulletSpawn[i].rotation) ;
			AudioSource[] allSources = this.GetComponents<AudioSource> ();
			if (this.gameObject.name == "Iowa(Clone)") {
				ShootSound = allSources [1];
				ShootSound.Play ();
			} else if (this.gameObject.name == "Yamato(Clone)") {
				ShootSound = allSources [0];
				ShootSound.Play ();
			}

			//clone.transform.parent = this.transform;//yield return new WaitForSeconds (20f);
		}
	}

	public void ShootButton(){
		
	}
}
