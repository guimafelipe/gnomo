using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour {

	public int id = 0;

	float rotationOfLane;
	float angleRotation = 72f;

	int numOfSpots = 5;

	[SerializeField]
	Spot[] spots ;

	// Use this for initialization
	void Start () {
		spots = new Spot[5];
		rotationOfLane = angleRotation * id;
		spots = GetComponentsInChildren<Spot> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateLane(){
		
	}

	public Spot GetSpot(int ind){
		//If spot exists, aka ind < 5 for now
		return spots [ind];
	}

	public void UpdateSpot(int i){
		spots [i].LetGnomoMove ();
	}

	public int size(){
		return spots.Length;
	}
}
