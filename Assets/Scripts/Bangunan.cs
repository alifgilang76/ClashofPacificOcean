using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Bangunan : MonoBehaviour{
	public bool selected = false;
	private bool selectedByClick = false;
	public GameObject selectionProjector=null;
	private GameObject projector=null;

	//public GameObject button = null;


	//public float floorOffset = 1;
	//public float speed = 10;
	//public float stopDistanceOffset = 0.5f;
	//private Vector3 moveToDest = Vector3.zero;

	// Use this for initialization


	// Update is called once per frame
	void Update () {
		GameObject Canvas = GameObject.Find ("Canvas");
		GameObject PanelUnit = Canvas.transform.GetChild (2).gameObject;
		GameObject Panel	= PanelUnit.transform.GetChild (0).gameObject;
		//GameObject panel = Canvas.transform.GetChild (0).gameObject;
		GameObject Text = Panel.transform.GetChild (0).gameObject;
		GameObject ButtonBattleship = Panel.transform.GetChild (1).gameObject;
		GameObject ButtonCruiser = Panel.transform.GetChild (2).gameObject;
		GameObject ButtonDestroyer = Panel.transform.GetChild (3).gameObject;

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
				projector.transform.localPosition = new Vector3 (0, 36, 0);					
				ButtonBattleship.SetActive (true);
				ButtonCruiser.SetActive (true);
				ButtonDestroyer.SetActive (true);
				Text.SetActive (true);
			} 
			if (!EventSystem.current.IsPointerOverGameObject ()) {
				if (!selected && projector != null) {
					GameObject.Destroy (projector);
					projector = null;
					ButtonBattleship.SetActive (false);
					ButtonCruiser.SetActive (false);
					ButtonDestroyer.SetActive (false);
					Text.SetActive (false);
					//GameObject.Find ("Canvas/PanelProgress").SetActive (false);
				}
			}
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
