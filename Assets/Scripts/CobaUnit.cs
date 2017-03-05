using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using RVO;

//tutor brent
public class CobaUnit : MonoBehaviour {
	private CameraOperator2 camShot;
	public bool selected = false;
	private bool selectedByClick = false;
	public GameObject selectionProjector=null;
	private GameObject projector=null;
	//public AttackIowa attackiowa ;
	public bool CekPosisiMusuh = false;
	Collider EnemyCollider,UnitCollider;
	Transform EnemyTransform,UnitTransform;
	int strength = 20;
	public Vector3 targetPosition;
	public Vector3 FlatPosition;
	//public Transform targetTransform;
	//public float turnSpeed = 0.05f;
	private Vector3 dir;
	public pathEnemy PathEnemy;
	public GameObject SimulatorGameObject, simulatorbefore;
	SimulatorComponent simulatorcomp;
	//The calculated path


	//The waypoint we are currently moving towards
	private int currentWaypoint = 0;

//
//	public float repathRate = 0.5f;
//	private float lastRepath = -9999;
//  variabel RVO
	public int _agentHandler;
	public float neighborDist;
	public int maxNeighbors;
	public float timeHorizon;
	public float timeHorizonObst;
	public float radius;
	public float maxSpeed;
	public float agentHeight;
	public bool isKinematic = false;

	Random random;

	//public Vector3 target;


	void Start () {
		camShot = GameObject.Find ("CameraController").transform.FindChild("RTSCamera").GetComponent<CameraOperator2>();
		random = new Random();
		targetPosition = transform.position;
	//	_agentHandler = Simulator.Instance.addAgent(transform.position, agentHeight, neighborDist, maxNeighbors, timeHorizon, timeHorizonObst, radius, maxSpeed, Vector2.zero, isKinematic);
//		simulatorbefore = GameObject.Find ("Simulator(Clone)");
//		//Simulator.Instance.Clear ();
//		Destroy (simulatorbefore.gameObject);
//		Simulator.Instance.Clear ();
//		Instantiate (SimulatorGameObject);
		_agentHandler = Simulator.Instance.addAgent(transform.position, agentHeight, neighborDist, maxNeighbors, timeHorizon, timeHorizonObst, radius, maxSpeed, Vector2.zero, isKinematic);

	}
//	private Vector3 processedVectorPath;
	// Update is called once per frame
	void Update () {
		//unitselected ();

			Debug.Log(Simulator.Instance.getNumAgents());
		if (GetComponent<Renderer> ().isVisible && Input.GetMouseButton (0)){ //gameObject.tag =="Unit") {
			
			if (!selectedByClick) {
				Vector3 camPos = Camera.main.WorldToScreenPoint (transform.position);
				camPos.y = CameraOperator2.InverMouseY (camPos.y);
				selected = CameraOperator2.selection.Contains (camPos);
				//selectedAI.Add(CameraOperator2.selection.Contains (camPos));

			}
			if (selected && projector == null ){ //selectedAI.Contains(this.gameObject) ) {
				projector = (GameObject)GameObject.Instantiate (selectionProjector);
				projector.transform.parent = transform;
				projector.transform.localPosition = new Vector3 (0, 28, 0);
					
			} else if (!selected && projector != null  ) {
				GameObject.Destroy (projector);
				projector = null;

			}
		}
		if (selected) {
			if (!camShot.selectedAI.Contains (gameObject)) {
				camShot.selectedAI.Add (gameObject);
			}

			//selectedAI.Add (this.gameObject);
			if (Input.GetMouseButtonUp (1)) {
				
				//newPosition = this.transform.position; //Set the "new" position equal to the current player's position
				targetPosition = CameraOperator2.GetDestination ();
				Vector3 center = Vector3.zero;
				foreach (GameObject unit in camShot.selectedAI) {
					if (unit != null) {
						center += unit.transform.position;
					}
				}
				//Debug.Log (total);
				center /=camShot.selectedAI.Count;


				targetPosition += transform.position - center;

			}

		} else if (!selected) {
			camShot.selectedAI.Remove(gameObject);
		}
			
		Vector3 pos = Simulator.Instance.getAgentPosition(_agentHandler);

		transform.position = pos;

//		if (CekPosisiMusuh == false) {
//			
//		} else if (CekPosisiMusuh == true) {
//			
//		}

		if (this.gameObject.name == "Yamato" || this.gameObject.name == "Yamato(Clone)" || this.gameObject.name == "Kagero" || this.gameObject.name == "Kagero(Clone)" || this.gameObject.name == "Mogami" || this.gameObject.name == "Mogami(Clone)") {
			targetPosition = PathEnemy.targetqueue;
		}

		dir = targetPosition - transform.position;
//		if (this.gameObject.name == "Iowa(Clone)") {
//			Debug.Log (Simulator.Instance.getAgentMaxSpeed(_agentHandler));
//		}
		Simulator.Instance.setAgentPrefVelocity (_agentHandler, dir);

		//Debug.DrawRay (transform.position, targetPosition);
		if (CekPosisiMusuh == false) {
			Vector3 v = Simulator.Instance.getAgentVelocity (_agentHandler);
			transform.rotation = Quaternion.LookRotation (new Vector3 (v.x, 0, v.z));
		}

		else if (CekPosisiMusuh == true) {
			if (EnemyCollider != null) {
				if (this.gameObject.name == "Iowa" || this.gameObject.name == "Iowa(Clone)" || this.gameObject.name == "Benson" || this.gameObject.name == "Benson(Clone)" || this.gameObject.name == "Baltimore" || this.gameObject.name == "Baltimore(Clone)") {
					Simulator.Instance.setAgentMaxSpeed (_agentHandler, 0);
					Quaternion targetrotation = Quaternion.LookRotation (EnemyCollider.transform.position - transform.position);
					float str = Mathf.Min (strength * Time.deltaTime, 1);
					transform.rotation = Quaternion.Lerp (transform.rotation, targetrotation, str);

				}
			} else if (UnitCollider != null) {
				if (this.gameObject.name == "Yamato" || this.gameObject.name == "Yamato(Clone)" || this.gameObject.name == "Kagero" || this.gameObject.name == "Kagero(Clone)" || this.gameObject.name == "Mogami" || this.gameObject.name == "Mogami(Clone)") {
					Simulator.Instance.setAgentMaxSpeed (_agentHandler, 0);
					Quaternion targetrotation = Quaternion.LookRotation (UnitCollider.transform.position - transform.position);
					float str = Mathf.Min (strength * Time.deltaTime, 1);
					transform.rotation = Quaternion.Lerp (transform.rotation, targetrotation, str);
					//Debug.Log ("musuh nembak");
				}
			} else if (EnemyCollider == null) {
				if (this.gameObject.name == "Iowa" || this.gameObject.name == "Iowa(Clone)") {
					this.gameObject.GetComponent<AttackIowa> ().stopAttack ();
					//gameObject.GetComponent<NavMeshAgent> ().Resume ();
				} else if (this.gameObject.name == "Benson" || this.gameObject.name == "Benson(Clone)") {
					this.gameObject.GetComponent<AttackDestroyer> ().stopAttack ();
					//gameObject.GetComponent<NavMeshAgent> ().Resume ();
				} else if (this.gameObject.name == "Baltimore" || this.gameObject.name == "Baltimore(Clone)") {
					this.gameObject.GetComponent<AttackCruiser> ().stopAttack ();	
					//gameObject.GetComponent<NavMeshAgent> ().Resume ();
				} else if (this.gameObject.name == "Yamato" || this.gameObject.name == "Yamato(Clone)") {
					this.gameObject.GetComponent<AttackIowa> ().stopAttack ();
					//gameObject.GetComponent<NavMeshAgent> ().Resume ();
				} else if (this.gameObject.name == "Kagero" || this.gameObject.name == "Kagero(Clone)") {
					this.gameObject.GetComponent<AttackDestroyer> ().stopAttack ();
					//gameObject.GetComponent<NavMeshAgent> ().Resume ();
				} else if (this.gameObject.name == "Mogami" || this.gameObject.name == "Mogami(Clone)") {
					this.gameObject.GetComponent<AttackCruiser> ().stopAttack ();	
					//gameObject.GetComponent<NavMeshAgent> ().Resume ();
				}
				CekPosisiMusuh = false;
				Simulator.Instance.setAgentMaxSpeed (_agentHandler, 20);
			}
				//Debug.Log ("unit bisa");
//			else if (UnitCollider == null) {
//				if (this.gameObject.name == "Yamato" || this.gameObject.name == "Yamato(Clone)") {
//					this.gameObject.GetComponent<AttackIowa> ().stopAttack ();
//					gameObject.GetComponent<NavMeshAgent> ().Resume ();
//				} else if (this.gameObject.name == "Kagero" || this.gameObject.name == "Kagero(Clone)") {
//					this.gameObject.GetComponent<AttackDestroyer> ().stopAttack ();
//					gameObject.GetComponent<NavMeshAgent> ().Resume ();
//				} else if (this.gameObject.name == "Mogami" || this.gameObject.name == "Mogami(Clone)") {
//					this.gameObject.GetComponent<AttackCruiser> ().stopAttack ();	
//					gameObject.GetComponent<NavMeshAgent> ().Resume ();
//				}
//				Debug.Log ("bisa");
//				CekPosisiMusuh = false;
//			}
				
				
//			if (cekPosisiMusuhIowa == true) {
//				gameObject.GetComponent<NavMeshAgent> ().Stop ();
//				Quaternion targetrotation = Quaternion.LookRotation (EnemyCollider.transform.position - transform.position);
//				float str = Mathf.Min (strength * Time.deltaTime, 1);
//				transform.rotation = Quaternion.Lerp (transform.rotation, targetrotation, str);
//				//transform.LookAt (EnemyCollider.transform);
//				//StartCoroutine("MulaiAttackIowa");
//				//this.gameObject.GetComponent<AttackIowa> ().StartAttack ();
//			} else if (cekPosisiMusuhBaltimore == true) {
//				gameObject.GetComponent<NavMeshAgent> ().Stop ();
//				Quaternion targetrotation = Quaternion.LookRotation (EnemyCollider.transform.position - transform.position);
//				float str = Mathf.Min (strength * Time.deltaTime, 1);
//				transform.rotation = Quaternion.Lerp (transform.rotation, targetrotation, str);
//				//transform.LookAt (EnemyCollider.transform);
//				//StartCoroutine("MulaiAttackIowa");
//				//this.gameObject.GetComponent<AttackCruiser> ().StartAttack ();
//			} else if (cekPosisiMusuhBenson == true) {
//				gameObject.GetComponent<NavMeshAgent> ().Stop ();
//				Quaternion targetrotation = Quaternion.LookRotation (EnemyCollider.transform.position - transform.position);
//				float str = Mathf.Min (strength * Time.deltaTime, 1);
//				transform.rotation = Quaternion.Lerp (transform.rotation, targetrotation, str);
//				//transform.LookAt (EnemyCollider.transform);
//				//StartCoroutine("MulaiAttackIowa");
//				//this.gameObject.GetComponent<AttackDestroyer> ().StartAttack ();
//			}
		}
		//Debug.Log (target);
	}
		//UpdateMove ();
		


	private void OnMouseDown()
	{
		//if (gameObject.tag == "Unit") {
			selectedByClick = true;
			selected = true;


		//}
	}

	public void setagent()
	{
		_agentHandler = Simulator.Instance.addAgent(transform.position, agentHeight, neighborDist, maxNeighbors, timeHorizon, timeHorizonObst, radius, maxSpeed, Vector2.zero, isKinematic);
	}

	public Vector3 getPos()
	{
		return Simulator.Instance.getAgentPosition (_agentHandler);
	}
	private void OnMouseUp()
	{
		if (selectedByClick) 
			selected = true;
		
		selectedByClick = false;

		//Debug.Log (camShot.selectedAI.Count);
		//selectedAI.Clear();
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "EnemyProximity") {
			if (this.gameObject.name == "Iowa" || this.gameObject.name == "Iowa(Clone)") {
				if (EnemyCollider == null) {
					EnemyCollider = other;
					EnemyTransform = other.transform;
					//cekPosisiMusuhIowa = true;
					Debug.Log ("kedetect");
					this.gameObject.GetComponent<AttackIowa> ().StartAttack ();

				}
			} else if (this.gameObject.name == "Benson" || this.gameObject.name == "Benson(Clone)") {
				if (EnemyCollider == null) {
					EnemyCollider = other;
					EnemyTransform = other.transform;
					//cekPosisiMusuhBenson = true;
					//transform.LookAt (other.transform);
					//gameObject.GetComponent<NavMeshAgent> ().Stop ();
					this.gameObject.GetComponent<AttackDestroyer> ().StartAttack ();
					//CekPosisiMusuh = true;
				}
			} else if (this.gameObject.name == "Baltimore" || this.gameObject.name == "Baltimore(Clone)") {
				if (EnemyCollider == null) {
					EnemyCollider = other;
					EnemyTransform = other.transform;
					//cekPosisiMusuhBaltimore = true;
					//transform.LookAt (other.transform);
					//gameObject.GetComponent<NavMeshAgent> ().Stop ();
					this.gameObject.GetComponent<AttackCruiser> ().StartAttack ();
					//CekPosisiMusuh = true;
				}
			}
			CekPosisiMusuh = true;
		} else if (other.tag == "UnitProximity") {
			if (this.gameObject.name == "Yamato" || this.gameObject.name == "Yamato(Clone)") {
				if (UnitCollider == null) {
					UnitCollider = other;
					UnitTransform = other.transform;//cekPosisiMusuhIowa = true;
					this.gameObject.GetComponent<AttackIowa> ().StartAttack ();
					//CekPosisiMusuh = true;
				}
			} else if (this.gameObject.name == "Kagero" || this.gameObject.name == "Kagero(Clone)") {
				if (UnitCollider == null) {
					UnitCollider = other;
					UnitTransform = other.transform;
					//cekPosisiMusuhBenson = true;
					//transform.LookAt (other.transform);
					//gameObject.GetComponent<NavMeshAgent> ().Stop ();
					this.gameObject.GetComponent<AttackDestroyer> ().StartAttack ();
					//CekPosisiMusuh = true;
					Debug.Log ("Enemy detected");
				}
			} else if (this.gameObject.name == "Mogami" || this.gameObject.name == "Mogami(Clone)") {
				if (UnitCollider == null) {
					UnitCollider = other;
					UnitTransform = other.transform;//cekPosisiMusuhBaltimore = true;
					this.gameObject.GetComponent<AttackCruiser> ().StartAttack ();
					//CekPosisiMusuh = true;
				}
			}
			CekPosisiMusuh = true;
		}
	}
		  

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "EnemyProximity") {
			if (this.gameObject.name == "Iowa" || this.gameObject.name == "Iowa(Clone)") {
				//cekPosisiMusuhIowa = false;
				this.gameObject.GetComponent<AttackIowa> ().stopAttack ();
				//gameObject.GetComponent<NavMeshAgent> ().Resume ();

			} else if (this.gameObject.name == "Benson" || this.gameObject.name == "Benson(Clone)") {
				//cekPosisiMusuhBenson= false;
				this.gameObject.GetComponent<AttackDestroyer> ().stopAttack ();	
				//gameObject.GetComponent<NavMeshAgent> ().Resume ();
				//CekPosisiMusuh = false;
			} else if (this.gameObject.name == "Baltimore" || this.gameObject.name == "Baltimore(Clone)") {
				//cekPosisiMusuhBaltimore = false;
				this.gameObject.GetComponent<AttackCruiser> ().stopAttack ();	
				//gameObject.GetComponent<NavMeshAgent> ().Resume ();
				//CekPosisiMusuh = false;
			}
			CekPosisiMusuh = false;
		} else if (other.tag == "UnitProximity") {
			if (this.gameObject.name == "Yamato" || this.gameObject.name == "Yamato(Clone)") {
				//cekPosisiMusuhIowa = false;
				this.gameObject.GetComponent<AttackIowa> ().stopAttack ();
				//gameObject.GetComponent<NavMeshAgent> ().Resume ();
				//CekPosisiMusuh = false;
			} else if (this.gameObject.name == "Kagero" || this.gameObject.name == "Kagero(Clone)") {
				//cekPosisiMusuhBenson= false;
				this.gameObject.GetComponent<AttackDestroyer> ().stopAttack ();	
				//gameObject.GetComponent<NavMeshAgent> ().Resume ();
				//CekPosisiMusuh = false;
			} else if (this.gameObject.name == "Mogami" || this.gameObject.name == "Mogami(Clone)") {
				//cekPosisiMusuhBaltimore = false;
				this.gameObject.GetComponent<AttackCruiser> ().stopAttack ();	
				//gameObject.GetComponent<NavMeshAgent> ().Resume ();
				//CekPosisiMusuh = false;
			}
			CekPosisiMusuh = false;
		}
	}





	void FaceTarget(Vector3 pt){
		Vector3 lookAtPt = pt;
		lookAtPt.y = transform.position.y;

		transform.LookAt(lookAtPt);
	}

	public void setPosition(Vector3 pos)
	{
		Simulator.Instance.setAgentPosition(_agentHandler, pos);
	}

//	void setPreferredVelocities(Vector3 velocity)
//	{
//		float angle = (float)Random.value * 2.0f * (float)Mathf.PI;
//		float dist = (float)Random.value * 0.0001f;
//		Simulator.Instance.setAgentPrefVelocity(_agentHandler, velocity + dist * new Vector3((float)Mathf.Cos(angle), 0, (float)Mathf.Sin(angle)));
//	}
//
	void OnDrawGizmos()
	{
		//Gizmos.DrawWireSphere (transform.position, neighborDist);
		//Gizmos.DrawWireSphere (transform.position, radius);
	}
//

}






		/*private void UpdateMove()
		{
			if (moveToDest != Vector3.zero && transform.position != moveToDest) {
				Vector3 direction = (moveToDest - transform.position).normalized;
				direction.y = 0;
				transform.GetComponent<Rigidbody>().velocity = direction * speed;

				if (Vector3.Distance (transform.position, moveToDest) < stopDistanceOffset)
					moveToDest = Vector3.zero;
			} else
				transform.GetComponent<Rigidbody>().velocity= Vector3.zero;
		}
	}*/



