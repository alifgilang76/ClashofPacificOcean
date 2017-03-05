using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RVO;

public class SpawnerMain : MonoBehaviour {
	public GameObject PanelProgress;
	BuildProgress buildprogress;
	bool bolIsBuild = false;
	CobaUnit cobaunit;
	Queue<SpawnerVar> QueueSpawner = new Queue<SpawnerVar>();
	SpawnerVar BuildNow;
	public Vector3 posisisebelum;

	class SpawnerVar {
		public float fltBuildTime = 0f;
		public GameObject goShipType;
		public Transform SpawnLocation;

		public SpawnerVar(float Time, GameObject Ship, Transform Location) {
			fltBuildTime = Time;
			goShipType = Ship;
			SpawnLocation = Location;
		}
	}

	public void AddShip(float Time, GameObject Ship, Transform Location) {
		if (bolIsBuild) {
			QueueSpawner.Enqueue(new SpawnerVar(Time, Ship, Location));
		} else {
			BuildNow = new SpawnerVar(Time, Ship, Location);
			bolIsBuild = true;

			PanelProgress.SetActive(true);
			buildprogress.doProgressRun = true;
			buildprogress.fltBuildTime = Time;
			buildprogress.fltElapsedTime = 0f;
			buildprogress.progressSlider.maxValue = Time;
		}
	}

	// Use this for initialization
	void Start () {
		buildprogress = PanelProgress.GetComponent<BuildProgress>();
	}
	
	// Update is called once per frame
	void Update () {
		if (bolIsBuild) {
			BuildNow.fltBuildTime -= Time.deltaTime;

			if (BuildNow.fltBuildTime <= 0) {
				
				Instantiate (BuildNow.goShipType, BuildNow.SpawnLocation.transform.position, Quaternion.Euler (0, 41, 0));

				if (QueueSpawner.Count > 0) {
					BuildNow = QueueSpawner.Dequeue ();

					PanelProgress.SetActive(true);
					buildprogress.doProgressRun = true;
					buildprogress.fltBuildTime = BuildNow.fltBuildTime;
					buildprogress.fltElapsedTime = 0f;
					buildprogress.progressSlider.maxValue = BuildNow.fltBuildTime;

				}
				else
					bolIsBuild = false;
			}
		}
	}
}
