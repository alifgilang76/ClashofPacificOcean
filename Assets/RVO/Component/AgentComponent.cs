using UnityEngine;
using System.Collections;
using RVO;

public class AgentComponent : MonoBehaviour {

    private int _agentHandler;
    public float neighborDist;
    public int maxNeighbors;
    public float timeHorizon;
    public float timeHorizonObst;
    public float radius;
    public float maxSpeed;
    public float agentHeight;
    public bool isKinematic = false;

    Random random;

    public Vector3 target;
   
    // Use this for initialization
    void Start () {
        random = new Random();
        _agentHandler = Simulator.Instance.addAgent(transform.position, agentHeight, neighborDist, maxNeighbors, timeHorizon, timeHorizonObst, radius, maxSpeed, Vector2.zero, isKinematic);

    }

    public void setPosition(Vector3 pos)
    {
        Simulator.Instance.setAgentPosition(_agentHandler, pos);
    }

    void setPreferredVelocities(Vector3 velocity)
    {
        float angle = (float)Random.value * 2.0f * (float)Mathf.PI;
        float dist = (float)Random.value * 0.0001f;
        Simulator.Instance.setAgentPrefVelocity(_agentHandler, velocity + dist * new Vector3((float)Mathf.Cos(angle), 0, (float)Mathf.Sin(angle)));
    }

    // Update is called once per frame
    void Update () {
        Vector3 pos = Simulator.Instance.getAgentPosition(_agentHandler);
        transform.position = pos;
		target = CameraOperator2.GetDestination ();
		target.y = 28;
        Simulator.Instance.setAgentPrefVelocity(_agentHandler, target - transform.position);
	}
}
