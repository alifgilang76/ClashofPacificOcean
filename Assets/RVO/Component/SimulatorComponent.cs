using UnityEngine;
using System.Collections;
using RVO;

public class SimulatorComponent : MonoBehaviour {
	//RVO.Simulator sim = new RVO.Simulator ();
	// Use this for initialization
	void Start () {
        StartCoroutine(DoStep());
	}

    IEnumerator DoStep()
    {
        while (true)
        {
			
            yield return new WaitForEndOfFrame();
			Simulator.Instance.setTimeStep(Time.deltaTime);
			yield return Simulator.Instance.doStep();

        }
            
    }

//	public void deleteSim()
//	{
//		sim = null;
////	}
}
//	void Update()
//	{
//		//yield return new WaitForEndOfFrame();
//		Simulator.Instance.setTimeStep(Time.deltaTime);
//		 Simulator.Instance.doStep();
//	}
//}
