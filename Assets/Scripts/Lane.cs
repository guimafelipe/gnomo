﻿using System.Collections;
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
		spots = new Spot[numOfSpots];
		rotationOfLane = angleRotation * id;
		spots = GetComponentsInChildren<Spot> ();
	}
	
	// Update is called once per frame
	/*void Update () {
		
	}

	public void UpdateLane(){
		
	}*/

	public Spot GetSpot(int ind){
		//If spot exists, aka ind < 5 for now
		Debug.Assert(ind >= 0);
		return spots [ind];
	}

	public void UpdateSpot(int i){
		spots [i].LetGnomoMove ();
	}

	public int size(){
		return spots.Length;
	}

	public void GotShoot(int dmg){
		//Debug.Log ("lane recebeu o tiro");
		for (int i = 0; i < size (); i++) {
			if (spots [i].HasGnomo ()) {
				spots [i].DamageGnomo (dmg);
			}
		}
	}

}
