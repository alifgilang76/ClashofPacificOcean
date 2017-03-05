using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour {


	public GameObject vessel;
	public GameObject[] countEnemy;
	public Transform spawnLocation;
	public float spawnWait;
	public float spawnMostWait;
	public float spawnLeastWait;
	public int startWait;
	public bool stop;
	public int level;
	//public Timer timer;
	public Text leveltext;

	int randvessel;
	//int urutan = 0;


	// Use this for initialization
	void Start () {
		StartCoroutine (waitSpawner ());
		InvokeRepeating ("UpdateSpawnTime", 120, 120);
		leveltext.text = ("Level = " + level);
	}

	// Update is called once per frame
	void Update () {
//		if (timer.timeLeft == 10 ) {
//			spawnMostWait = spawnMostWait - 10;
//			spawnLeastWait = spawnLeastWait - 10;
//			startWait = startWait - 10;
//		}
			Debug.Log (spawnMostWait);
////		Debug.Log (spawnLeastWait);
////		Debug.Log (startWait);
		countEnemy= GameObject.FindGameObjectsWithTag ("Enemy");
		int count = countEnemy.Length;
		if (count <= 30) {
			spawnWait = Random.Range (spawnLeastWait, spawnMostWait);
		}
			
	}

	IEnumerator waitSpawner ()
	{
		yield return new WaitForSeconds (startWait);
		while (!stop) {
			//randvessel = Random.Range (0, 3);
			Instantiate (vessel, spawnLocation.transform.position, Quaternion.Euler (0, 221, 0));
			//urutan++;
			yield return new WaitForSeconds (spawnWait);
		}
	}

	void UpdateSpawnTime()
	{
		if (spawnMostWait > 0) {
			spawnMostWait = spawnMostWait - 10;
		}
		if (spawnLeastWait > 0)
		{
			spawnLeastWait = spawnLeastWait - 10;
		}
		if (startWait > 0) {
			startWait = startWait - 10;
		}
		level = level + 1;
		leveltext.text = ("Level = " + level);
	}
}
