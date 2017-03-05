using UnityEngine;
using System.Collections;

public class pathEnemy : MonoBehaviour {

	public Transform currentPath;
	public Transform[] Path;
	public Vector3 targetqueue;
	private int y, ybefore = 0;


	void Start () {

		targetqueue = Path [y].position;
	}
		
	int RandomY(int Ybefore)
	{
		if (Ybefore == 0) {
			y = Random.Range (1, 2);
		} else if (Ybefore == 1 || Ybefore == 2) {
			y = Random.Range (3, 8);
		} else if (Ybefore == 3 || Ybefore == 4 || Ybefore == 5 || Ybefore == 6 || Ybefore == 7 || Ybefore == 8) {
			y = Random.Range (9, 11);
		} else if (Ybefore == 9 || Ybefore == 10 || Ybefore == 11) {
			y = Random.Range (12, 16);
		} else if (Ybefore == 12 || Ybefore == 13 || Ybefore == 14 || Ybefore == 15) {
			y = Random.Range (17, 19);
		} else if (Ybefore == 16 || Ybefore == 17 || Ybefore == 18) {
			y = 19;
		}
		return y;
	}

	// Update is called once per frame
	void Update () {
		var distPath = Vector3.Distance (Path [y].position, transform.position);
		currentPath = Path [y];
		ybefore = y;
		//y = Random.Range (0, 18);
		if (distPath < 1) {
			RandomY (ybefore);
			if (y > ybefore) {
				targetqueue= Path [y].position;
				Debug.Log (y);
				//this.GetComponent<CobaUnit> ().isMoving = true;
			} 
		}

	}

}
