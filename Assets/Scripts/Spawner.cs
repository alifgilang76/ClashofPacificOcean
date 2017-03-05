using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject BuildingBuilder;
	public Transform spawnLocation;
	public GameObject spawnPrefab;
	public GameObject spawnClone;
	public float fltTime = 0f;

	int i, x;

	void Start(){
	}

//	public void spawnUnit()
//	{
//		spawnClone = Instantiate (spawnPrefab, spawnLocation.transform.position, Quaternion.Euler (0, 41, 0)) as GameObject;
//	}

	public void OnClick (){
		BuildingBuilder.GetComponent<SpawnerMain> ().AddShip (fltTime, spawnPrefab, spawnLocation);
		//Invoke ("spawnUnit", 4f);
	}

	void Update (){
		
	}
//
//	IEnumerator Spawning()
//	{
//		while (isBuild != false) {
//			yield return null;
//		}
//			isBuild = true;
//			yield return new WaitForSeconds (4f);
//			spawnClone = Instantiate (spawnPrefab, spawnLocation.transform.position, Quaternion.Euler (0, 41, 0)) as GameObject;
//			isBuild = false;
//	}
}
