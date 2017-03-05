using UnityEngine;


public class BuildingList {

	public GameObject buildingGameObject;
	public string buildingName;

	public BuildingList Constructor()
	{
		BuildingList capture = new BuildingList();

		capture.buildingGameObject = buildingGameObject;
		capture.buildingName = buildingName;

		return capture;
	}
}
