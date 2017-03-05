using UnityEngine;
using System.Collections;

public class AttackDestroyer : MonoBehaviour {
	public GameObject bulletPrefab;
	//public AudioClip shot;
	//GameObject clone;
	public Transform[] bulletSpawn;
	bool startAttack = false;
	float attackTime = 1f;
	AudioSource ShootSound;
	// Use this for initialization
	public void StartAttack () {
		if (!startAttack) {
			Shoot ();
			startAttack = true;
			attackTime = 1f;
		}

	}

	// Update is called once per frame
	void Update () {
		if (startAttack) {
			attackTime -= Time.deltaTime;
			if (attackTime <= 0) {
				Shoot ();
				attackTime = 1f;
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

			Instantiate (bulletPrefab, bulletSpawn [i].position, bulletSpawn[i].rotation);
			AudioSource[] allSources = this.GetComponents<AudioSource> ();
			if ( this.gameObject.name == "Benson(Clone)") {
				ShootSound = allSources [1];
				ShootSound.Play ();
			}else if ( this.gameObject.name == "Kagero(Clone)") {
				ShootSound = allSources [0];
				ShootSound.Play ();
			}
			//this.GetComponent<AudioSource>().Play ();
			//clone.transform.parent = this.transform;//yield return new WaitForSeconds (20f);
			//Physics.IgnoreCollision (clone.GetComponent<CapsuleCollider>(), transform.parent.GetComponent<BoxCollider>()); 
		}
	}

}
