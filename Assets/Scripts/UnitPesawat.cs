using UnityEngine;
using System.Collections;

public class UnitPesawat : MonoBehaviour {

	public bool selected = false;
	private bool selectedByClick = false;
	public GameObject selectionProjector=null;
	private GameObject projector=null;

	//public float floorOffset = 1;
	//public float speed = 10;
	//public float stopDistanceOffset = 0.5f;
	//private Vector3 moveToDest = Vector3.zero;

	// Use this for initialization


	// Update is called once per frame
	void Update () {
		if (GetComponent<Renderer> ().isVisible && Input.GetMouseButton (0)) 
		{
			if (!selectedByClick) 
			{
				Vector3 camPos = Camera.main.WorldToScreenPoint (transform.position);
				camPos.y = CameraOperator2.InverMouseY (camPos.y);
				selected = CameraOperator2.selection.Contains (camPos);
			}
			if (selected && projector == null) 
			{
				projector = (GameObject)GameObject.Instantiate (selectionProjector);
				projector.transform.parent = transform;
				projector.transform.localPosition = new Vector3 (0, 38, 0);

			} 
			else if (!selected && projector != null) 
			{
				GameObject.Destroy (projector);
				projector = null;
			}
		}
		if (selected && Input.GetMouseButtonUp (1)) {
			Vector3 destination = CameraOperatorPesawat.GetDestination ();
			if (destination != Vector3.zero) {
				gameObject.GetComponent<NavMeshAgent> ().SetDestination (destination);
				//Quaternion.FromToRotation(Vector3.zero, destination);
				//moveToDest = destination;
				//moveToDest.y += floorOffset;
			}
		}
		//UpdateMove ();
	}

	private void OnMouseDown()
	{
		selectedByClick = true;
		selected = true;
	}

	private void OnMouseUp()
	{
		if (selectedByClick)
			selected = true;

		selectedByClick = false;
	}
}
