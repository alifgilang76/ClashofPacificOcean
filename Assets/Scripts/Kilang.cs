using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Kilang : MonoBehaviour {
	public bool selected = false;
	private bool selectedByClick = false;
	public GameObject selectionProjector=null;
	private GameObject projector=null;

	void Update () {
		if (GetComponent<Renderer> ().isVisible && Input.GetMouseButton (0)) {
			if (!selectedByClick) {
				Vector3 camPos = Camera.main.WorldToScreenPoint (transform.position);
				camPos.y = CameraOperator2.InverMouseY (camPos.y);
				selected = CameraOperator2.selection.Contains (camPos);
			}

			//{
			if (selected && projector == null) {
				projector = (GameObject)GameObject.Instantiate (selectionProjector);
				projector.transform.parent = transform;
				projector.transform.localPosition = new Vector3 (0, 1, 0);


			} 
			//if (!EventSystem.current.IsPointerOverGameObject ()) {
				if (!selected && projector != null) {
					GameObject.Destroy (projector);
					projector = null;

				}
			//}
		}
	}

	void OnMouseDown()
	{
		selectedByClick = true;
		selected = true;
	}

	void OnMouseUp()
	{
		if (selectedByClick)
			selected = true;

		selectedByClick = false;
	}


}
