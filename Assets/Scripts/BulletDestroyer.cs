using UnityEngine;
using System.Collections;

public class BulletDestroyer : MonoBehaviour {
	float speed;
	// Use this for initialization
	void Start () {
		speed = 50;
		Destroy (this.gameObject, 5);
	}

	// Update is called once per frame
	void Update () {
		transform.position += transform.right * Time.deltaTime* speed;
	}

	void OnCollisionEnter(Collision other)
	{
		
		if (other.gameObject.name == "Mogami" || other.gameObject.name == "Mogami(Clone)") {
			other.gameObject.GetComponent<MogamiHealth> ().Hit (Random.Range (0, 785));
		} else if (other.gameObject.name == "Iowa" || other.gameObject.name == "Iowa(Clone)") {
			other.gameObject.GetComponent<IowaHealth> ().Hit (Random.Range (0, 785));
		} else if (other.gameObject.name == "Baltimore" || other.gameObject.name == "Baltimore(Clone)") {
			other.gameObject.GetComponent<BaltimoreHealth> ().Hit (Random.Range (0, 785));
		} else if (other.gameObject.name == "Benson" || other.gameObject.name == "Benson(Clone)") {
			other.gameObject.GetComponent<BensonHealth> ().Hit (Random.Range (0, 785));
		} else if (other.gameObject.name == "Yamato" || other.gameObject.name == "Yamato(Clone)") {
			other.gameObject.GetComponent<YamatoHealth> ().Hit (Random.Range (0, 785));
		} else if (other.gameObject.name == "Kagero" || other.gameObject.name == "Kagero(Clone)") {
			other.gameObject.GetComponent<KageroHealth> ().Hit (Random.Range (0, 785));
		} else if (other.gameObject.name == "Port" || other.gameObject.name == "PortMusuh") {
			other.gameObject.GetComponent<PortHealth> ().Hit (Random.Range (0, 785));
		} else if (other.gameObject.name == "OilRig") {
			other.gameObject.GetComponent<OilHealth> ().Hit (Random.Range (0, 785));
		} else if (other.gameObject.name == "Factory 1") {
			other.gameObject.GetComponent<FactoryHealth> ().Hit (Random.Range (0, 705));
		}	
		Destroy (this.gameObject);	
	}
}
