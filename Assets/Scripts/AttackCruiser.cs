using UnityEngine;
using System.Collections;

public class AttackCruiser : MonoBehaviour {
	public GameObject bulletPrefab;
	public Transform[] bulletSpawn;
	//public GameObject clone;
	bool startAttack = false;
	float attackTime = 5f;
	AudioSource ShootSound;
	// Use this for initialization
	public void StartAttack () {
		if (!startAttack) {
			Shoot ();
			startAttack = true;
			attackTime = 5f;
		}

	}

	// Update is called once per frame
	void Update () {
		if (startAttack) {
			
			attackTime -= Time.deltaTime;
			if (attackTime <= 0) {
				Shoot ();
				attackTime = 5f;
			}
		}

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
			if ( this.gameObject.name == "Baltimore(Clone)" ) {
				ShootSound = allSources [1];
				ShootSound.Play ();
			}else if ( this.gameObject.name == "Mogami(Clone)" ) {
				ShootSound = allSources [0];
				ShootSound.Play ();
			}
			//clone.transform.parent = this.transform;//yield return new WaitForSeconds (20f);
		}
	}

}
