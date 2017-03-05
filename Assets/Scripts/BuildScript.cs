using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuildScript : MonoBehaviour {


	BuildManager bm;
	Button factory, oil;
	bool buildopen = false;

	// Use this for initialization
	void Start () {
		bm = GameObject.Find("BuildManager").GetComponent<BuildManager>();
		Canvas cv = GameObject.Find("Canvas").GetComponent<Canvas>();

		factory = cv.transform.FindChild("Panel Build").FindChild("Panel (1)").FindChild("FactoryButton").gameObject.GetComponent<Button>();
		oil = cv.transform.FindChild("Panel Build").FindChild("Panel (1)").FindChild("OilButton").gameObject.GetComponent<Button>();
	}

	public void ActiveteBuilding(Button pressedBtn)
	{
		if (pressedBtn.name == "BuildButton")
		{
			if (buildopen)
			{
				//bm.DeactivateBuildingmode();
				factory.gameObject.SetActive(false);
				oil.gameObject.SetActive(false);
				pressedBtn.image.color = Color.white;
				buildopen = false;
			}
			else
			{
				//bm.ActivateBuildingmode();
				factory.gameObject.SetActive(true);
				oil.gameObject.SetActive(true);
				pressedBtn.image.color = new Color(255, 0, 255);
				buildopen = true;

			}
		}
		else
		{
			switch (pressedBtn.name)
			{
			case "FactoryButton":
				bm.SelectBuilding(0);
				break;
			case "OilButton":
				bm.SelectBuilding(1);
				break;

			}

			pressedBtn.image.color = new Color(155, 120, 255);
			bm.ActivateBuildingmode();

		}

	}

	void Update()
	{
		if (buildopen)
		{
			if (!bm.isBuildingEnabled)
			{
				if (factory.image.color != Color.white)
					factory.image.color = Color.white;

				if (oil.image.color != Color.white)
					oil.image.color = Color.white;
			}
		}
	}
}
