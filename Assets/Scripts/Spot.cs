using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour {


	public IGnomo gnomoInSpot;

	public void SetGnomoInSpot(Gnomo gnomo){
		gnomoInSpot = gnomo;
	}

	public IGnomo GetGnomo(){
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
