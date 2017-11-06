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
		for (int i = 0; i < numOfSpots; i++) {
			Spot _spot = spots [i];
			int gnomoSteps = _spot.GetGnomoNmbOfSteps();
			if (gnomoSteps > 0) {
				if (i - gnomoSteps < 0) {
					//Gnomo chegou no player, avisar ao manager e chamar lose scene.

				} else {
					//Verificar se o gnomo pode fazer o movimento
					if (!spots [i - gnomoSteps].HasGnomo()) { //Significa que não tem gnomo
						spots[i - gnomoSteps].SetGnomoInSpot(_spot.GetGnomo());
						_spot.RemoveGnomoFromSpot();
					}
				}
			}
		}
	}
}
