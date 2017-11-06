using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour {


	public Gnomo gnomoInSpot;

	public void SetGnomoInSpot(Gnomo gnomo){
		gnomoInSpot = gnomo;
		gnomoInSpot.SetNewPosition (this.transform);
	}

	public Gnomo GetGnomo(){
		return gnomoInSpot;
	}

	public bool HasGnomo(){
		if (gnomoInSpot == null) {
			return false;
		} else {
			return true;
		}
	}

	public int GetGnomoNmbOfSteps(){
		if (gnomoInSpot != null) {
			return gnomoInSpot.nSteps;
		} 
		return -1;
	}

	public void RemoveGnomoFromSpot(){
		gnomoInSpot = null;
	}

}
