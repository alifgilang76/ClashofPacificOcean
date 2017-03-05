using UnityEngine;
using System.Collections;

public class MousePoint : MonoBehaviour {

	RaycastHit hit;

	public GameObject Target,TargetMusuh;
	public float raycastLength = 500;


	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay ((Input.mousePosition));

		if (Physics.Raycast (ray, out hit, raycastLength)) {
			if (hit.collider.name == "Tile" ) {
				if (Input.GetMouseButtonDown (1)) {
					GameObject TargetObj = Instantiate (Target, hit.point, Quaternion.identity)as GameObject;
					TargetObj.name = "Target";
				}
			}

			if (hit.collider.tag == "Enemy" ) {
				if (Input.GetMouseButtonDown (1)) {
					GameObject TargetObj = Instantiate (TargetMusuh, hit.point, Quaternion.identity)as GameObject;
					TargetObj.name = "TargetMusuh";
				}
			}
		}


	}

}
