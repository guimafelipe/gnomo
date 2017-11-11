using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	float rotationSpeed = 25f;
	[SerializeField]
	float rotationAngle = 45f;



	enum rotatingStates {rotatingLeft, rotatingRight, stopped};

	[SerializeField]
	int playerState;

	public int maxBullets = 6;
	public int bullets;
	public int dmg = 1;

	public int laneAimed = 0;
	private int numLanes = 5;
	private LevelMap levelMap;
	private const float EPS = 0.01f;
	//Refatorar:

	Quaternion targetRotation;

	// Use this for initialization
	void Start () {
		levelMap = GameObject.Find ("LevelMap").GetComponent<LevelMap> ();
		transform.rotation = Quaternion.Euler (transform.eulerAngles.x, 0f ,transform.eulerAngles.z);
		laneAimed = 2;
		bullets = maxBullets;
		playerState = (int)rotatingStates.stopped;
	}
	
	// Update is called once per frame
	void Update () {

		if (bullets == 0) {
			Reload ();
			return;
		}

		if (playerState == (int)rotatingStates.stopped) {
			
			if (Input.GetKeyDown (KeyCode.A)) {
				//Rotate Left
				if (laneAimed > 0) { 
					playerState = (int)rotatingStates.rotatingLeft;
					RotateLeft ();
					laneAimed--;
				}

			}
			else if (Input.GetKeyDown (KeyCode.D)) {
				//Rotate Right
				if (laneAimed < numLanes - 1) {
					playerState = (int)rotatingStates.rotatingRight;
					RotateRight ();
					laneAimed++;
				}
			}
			if (Input.GetKeyDown (KeyCode.Space)) {
				//Shoot
				//Debug.Log("espaço");
				Shoot();
				return;
			}

		}

		else if (playerState == (int)rotatingStates.rotatingLeft) {
			DoRotatingLeftAnim ();
		}

		else if (playerState == (int)rotatingStates.rotatingRight) {
			DoRotatingRightAnim ();
		}

	}

	#region RotatingMethods
	void RotateLeft(){
		float roundedPos = (float)(int)(transform.eulerAngles.y + 0.5f);
		targetRotation = Quaternion.Euler(transform.eulerAngles.x, roundedPos - rotationAngle, transform.eulerAngles.z);
	}

	void DoRotatingLeftAnim(){
		transform.rotation = Quaternion.RotateTowards (transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
		if (Mathf.Abs(transform.rotation.eulerAngles.y - targetRotation.eulerAngles.y) < EPS) {
			transform.rotation = targetRotation;
			playerState = (int)rotatingStates.stopped;
		}
	}

	void RotateRight(){
		float roundedPos = (float)(int)(transform.eulerAngles.y + 0.5f);
		targetRotation = Quaternion.Euler(transform.eulerAngles.x, roundedPos + rotationAngle, transform.eulerAngles.z);
	}



	void DoRotatingRightAnim(){
		transform.rotation = Quaternion.RotateTowards (transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
		if (Mathf.Abs(transform.rotation.eulerAngles.y - targetRotation.eulerAngles.y) < EPS) {
			transform.rotation = targetRotation;
			playerState = (int)rotatingStates.stopped;
		}
	}
	#endregion

	void Shoot(){
		if (bullets > 0) {
			levelMap.ShootLane (laneAimed, dmg);
			//Debug.Log ("atirei");
			bullets--;
		}
	}

	void Reload(){
		//Do reload animation
		bullets = maxBullets;
		levelMap.UpdateMap ();
	}

}
