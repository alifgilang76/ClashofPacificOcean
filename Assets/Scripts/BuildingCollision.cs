using UnityEngine;
using System.Collections;

public class BuildingCollision : MonoBehaviour {

	private bool isCollided = false;
	public bool Collided()
	{
		return isCollided;
	}

	private BuildManager buildMan = null;

	void Start()
	{
		buildMan = GameObject.Find("BuildManager").GetComponent<BuildManager>();
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.gameObject.tag != buildMan.TerrainCollisionTag)
		{
			isCollided = true;
		}
	}

	void OnCollisionExit()
	{
		isCollided = false;
	}
}
