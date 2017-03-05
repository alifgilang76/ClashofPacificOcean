using UnityEngine;
using System.Collections;

public class Economy : MonoBehaviour {
	public int SteelRes,FuelRes ;
	public GameObject[] GetSteelProd;
	public CollectSteel CollectedSteel;
	public GameObject[] GetFuelProd;
	public CollectFuel CollectedFuel;

	private float nextActionTime = 0.0f;
	public float period = 1f;

	// Use this for initialization
	void Start () {
		SteelRes = 10000;
		FuelRes = 10000;
		GameObject GetSteelProd = GameObject.FindWithTag ("Factory");
		CollectedSteel = GetSteelProd.GetComponent<CollectSteel> ();
		GameObject GetFuelProd = GameObject.FindWithTag ("Fuel");
		CollectedFuel = GetFuelProd.GetComponent<CollectFuel> ();
	}

	public void OnClickBattleship()
	{
		SteelRes = SteelRes - 1800;
		FuelRes = FuelRes - 700;
	}

	public void OnClickCruiser()
	{
		SteelRes = SteelRes - 1300;
		FuelRes = FuelRes - 250;
	}

	public void OnClickDestroyer()
	{
		SteelRes = SteelRes - 900;
		FuelRes = FuelRes - 100;
	}

	public void OnClickOilRig()
	{
		SteelRes = SteelRes - 3400;
		FuelRes = FuelRes - 1200;
	}

	public void OnClickFactory()
	{
		SteelRes = SteelRes - 3200;
		FuelRes = FuelRes - 1800;
	}

	// Update is called once per frame
	void Update () {
		GetSteelProd = GameObject.FindGameObjectsWithTag ("Factory");
		int count = GetSteelProd.Length;
		GetFuelProd = GameObject.FindGameObjectsWithTag ("Fuel");
		int count2 = GetFuelProd.Length;
		if (Time.time > nextActionTime ) {
			nextActionTime += period;
			SteelRes = SteelRes + (count* CollectedSteel.increase);
			FuelRes = FuelRes + (count2* CollectedFuel.increase);

		}

	}
		
}
