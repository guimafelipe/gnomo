using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	float rotationSpeed = 25f;
	[SerializeField]
	float rotationAngle = 72f;

	enum rotatingStates {rotatingLeft, rotatingRight, stopped};

	[SerializeField]
	int playerState;

	bool isRotating = false;


	//Refatorar:

	Quaternion targetRotation;

	/*[SerializeField]
	float originalYRot;*/

	// Use this for initialization
	void Start () {
		playerState = (int)rotatingStates.stopped;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerState == (int)rotatingStates.stopped) {
			if (Input.GetKeyDown (KeyCode.A)) {
				//Rotate Left
				playerState = (int)rotatingStates.rotatingLeft;
				RotateLeft ();
			} else if (Input.GetKeyDown (KeyCode.D)) {
				//Rotate Right
				playerState = (int)rotatingStates.rotatingRight;
				RotateRight ();
			} else if (Input.GetMouseButtonDown (0)) {
				//Shoot
			}
		}

		else if (playerState == (int)rotatingStates.rotatingLeft) {
			DoRotatingLeftAnim ();
		}

		else if (playerState == (int)rotatingStates.rotatingRight) {
			DoRotatingRightAnim ();
		}

	}
		

	void RotateLeft(){
		//originalYRot = transform.rotation.y;
		targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + rotationAngle, transform.eulerAngles.z);
	}

	void DoRotatingLeftAnim(){
		/*transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(
			transform.rotation.x, originalYRot + rotationAngle, transform.rotation.z), Time.deltaTime * rotationSpeed);
		if (transform.rotation.y == originalYRot + rotationAngle) {
			playerState = (int)rotatingStates.stopped;
		}*/
		transform.rotation = Quaternion.RotateTowards (transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
		if (transform.rotation == targetRotation) {
			playerState = (int)rotatingStates.stopped;
		}

	}

	void RotateRight(){
		//originalYRot = transform.rotation.y;
		targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y - rotationAngle, transform.eulerAngles.z);
	}

	void DoRotatingRightAnim(){

		transform.rotation = Quaternion.RotateTowards (transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
		if (transform.rotation == targetRotation) {
			playerState = (int)rotatingStates.stopped;
		}

	}


}
