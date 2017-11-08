using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMap : MonoBehaviour {

	[SerializeField]
	Lane[] lanes;

	// Use this for initialization
	void Start () {
		lanes = GetComponentsInChildren<Lane> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Lane GetLane(int ind){
		//if lane exists, aka ind < 5 for now.
		return lanes [ind];
	}

	public Spot GetSpot(int x, int y){
		return GetLane (x).GetSpot (y);
	}

	public bool CheckIfSpotIsEmpty(int x, int y){
		if (GetSpot (x, y).HasGnomo() == false) {
			return true;
		} else {
			return false;
		}
	}

	public void UpdateMap(){
		for (int i = 0; i < lanes.Length; i++) {
			for (int j = 0; j < lanes [i].size (); j++) {
				lanes [i].UpdateSpot (j);
			}
		}
	}

}
