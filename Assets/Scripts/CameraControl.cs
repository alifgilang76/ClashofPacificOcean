using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	
	public struct BoxLimit
	{
		public float leftLimit;
		public float rightLimit;
		public float topLimit;
		public float bottomLimit;
	}

	public static BoxLimit controlLimits = new BoxLimit();
	public static BoxLimit mouseScrollLimits = new BoxLimit();
	public static CameraControl instance;

	private float cameraMoveSpeed = 300f;
	private float shiftBonus = 45f;
	private float mouseBoundary = 25f;

	private float mouseX;
	private float mouseY;

	//private bool VerticalRotationEnabled = true;
	//private float VerticalRotationMin = 0f;
	//private float VerticalRotationMax = 180f;

	public Terrain WorldTerrain;
	public float WorldTerrainPadding = 25f;

	void Awake()
	{
		instance = this;
	}
	// Use this for initialization
	void Start ()
	{
		controlLimits.leftLimit = WorldTerrain.transform.position.x + WorldTerrainPadding;
		controlLimits.rightLimit = WorldTerrain.terrainData.size.x - WorldTerrainPadding;
		controlLimits.topLimit = WorldTerrain.terrainData.size.z - WorldTerrainPadding;
		controlLimits.bottomLimit = WorldTerrain.transform.position.z + WorldTerrainPadding;
	
		mouseScrollLimits.leftLimit = mouseBoundary;
		mouseScrollLimits.rightLimit = mouseBoundary;
		mouseScrollLimits.topLimit = mouseBoundary;
		mouseScrollLimits.bottomLimit = mouseBoundary;
	}

	// Update is called once per frame
	void LateUpdate ()
	{
		HandleMouseRotation ();
		if (CheckIfUserCameraInput())
		{
			Vector3 desiredTranslation = GetDesiredTranslation();

			if (!IsDesiredPositionOverBoundaries(desiredTranslation))
			{
				this.transform.Translate(desiredTranslation);
			}
		}

		mouseX = Input.mousePosition.x;
		mouseY = Input.mousePosition.y;
	}
		
	//rotasi mouse
	public void HandleMouseRotation()
	{
		var easeFactor = 20f;
		if(Input.GetMouseButton (2) && Input.GetKey ((KeyCode.LeftControl)))
		{
			//Horizotal rotation
				if(Input.mousePosition.x != mouseX)
				{
					var cameraRotationY = (Input.mousePosition.x - mouseX) * easeFactor *Time.deltaTime;
					this.transform.Rotate (0, cameraRotationY, 0);
				}
		}
	}
	//Cek Input dari user untuk menggerakkan kamera
	private bool CheckIfUserCameraInput()
	{
		bool keyboardMove;
		bool mouseMove;
		bool canMove;
			
		//cek keyboard
		if (CameraControl.AreCameraKeyboardButtonPressed())
		{
			keyboardMove = true;
		}
		else
			keyboardMove = false;
			
		//cek posisi mouse
		if (CameraControl.IsMousePositionWithinBoundaries())
		{
			mouseMove = true;
		} else mouseMove = false;


		if (keyboardMove || mouseMove)
		canMove = true;  else canMove = false;

		return canMove;
	}
		
	//menentukan lokasi kamera yang diinginkan sesuai input player
	public Vector3 GetDesiredTranslation()
	{
		float moveSpeed = 0f;
		Vector3 desiredTranslation = new Vector3 ();

		if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			moveSpeed = (cameraMoveSpeed + shiftBonus) * Time.deltaTime;
		}
		else
		{
			moveSpeed = cameraMoveSpeed * Time.deltaTime;
		}
			
		//Pergerakan kamera menggunakan keyboard / mouse
		if (Input.GetKey(KeyCode.W) || Input.mousePosition.y > (Screen.height - mouseScrollLimits.topLimit) )
		{
			desiredTranslation += Vector3.forward * moveSpeed;
		}
		if (Input.GetKey(KeyCode.S) || Input.mousePosition.y < mouseScrollLimits.bottomLimit)
		{
			desiredTranslation += Vector3.back * moveSpeed ;
		}
		if (Input.GetKey(KeyCode.A) || Input.mousePosition.x < mouseScrollLimits.leftLimit)
		{
			desiredTranslation += Vector3.left * moveSpeed;
		}
		if (Input.GetKey(KeyCode.D) || Input.mousePosition.x > (Screen.width - mouseScrollLimits.rightLimit))
		{
			desiredTranslation += Vector3.right * moveSpeed;
		}
			
		return desiredTranslation;
	}

	//cek apakah posisi tujuan melebihi batas
	public bool IsDesiredPositionOverBoundaries(Vector3 desiredTranslation)
	{
		Vector3 desiredWorldPosition = this.transform.TransformPoint ((desiredTranslation));

		bool overBoundaries = false;

		if(desiredWorldPosition.x < controlLimits.leftLimit)
		{
			overBoundaries = true;
		}
		if (desiredWorldPosition.x > controlLimits.rightLimit)
		{
			overBoundaries = true;
		}
		if (desiredWorldPosition.z > controlLimits.topLimit)
		{
			overBoundaries = true;
		}
		if (desiredWorldPosition.z < controlLimits.bottomLimit)
		{
			overBoundaries = true;
		}
		return overBoundaries;
	}
	public static bool AreCameraKeyboardButtonPressed()
	{
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
			return true;
		else return false;
	}
	public static bool IsMousePositionWithinBoundaries()
	{
		if (
			(Input.mousePosition.x < mouseScrollLimits.leftLimit && Input.mousePosition.x > -5) ||
			(Input.mousePosition.x > (Screen.width - mouseScrollLimits.rightLimit) && Input.mousePosition.x < (Screen.width + 5)) ||
			(Input.mousePosition.y < mouseScrollLimits.bottomLimit && Input.mousePosition.y > -5) ||
			(Input.mousePosition.y > (Screen.height - mouseScrollLimits.topLimit) && Input.mousePosition.y < (Screen.height + 5))
		)
		return true; else return false;
	}
}

