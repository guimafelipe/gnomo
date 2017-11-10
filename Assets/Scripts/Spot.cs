using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour {


	public IEnemy gnomoInSpot;

	public void SetGnomoInSpot(IEnemy gnomo){
		gnomoInSpot = gnomo;
	}

	public IEnemy GetGnomo(){
		return gnomoInSpot;
	}

	public bool HasGnomo(){
		if (gnomoInSpot == null) {
			return false;
		} else {
			return true;
		}
	}

	public void LetGnomoMove (){
		if (HasGnomo ()) {
			gnomoInSpot.TryToMove ();
			RemoveGnomoFromSpot ();
		}
	}

	public void RemoveGnomoFromSpot(){
		gnomoInSpot = null;
	}

}
