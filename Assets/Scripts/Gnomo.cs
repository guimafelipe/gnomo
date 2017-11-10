using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnomo : GnomoBase, IEnemy{





	// Use this for initialization
	void Start () {
		hp = maxHp;
		lvlMap = GameObject.Find ("LevelMap").GetComponent<LevelMap>();
		StartCoroutine (Spawnar (0.5f));
		//SetNewPosition (lvlMap.GetSpot (posX, posY));
	}

	IEnumerator Spawnar(float x){
		yield return new WaitForSeconds(x);
		SetNewPosition (lvlMap.GetSpot (posX, posY));

	}

	// Update is called once per frame
	void Update () {
		
	}


	//This method will be overrided for new types of gnomes. The below will work only for the base class gnome.
	public override void TryToMove(){
		if (lvlMap.CheckIfSpotIsEmpty (posX, posY - 1)) {
			SetNewPosition (lvlMap.GetSpot (posX, --posY));
		} else {
			SetNewPosition (lvlMap.GetSpot (posX, posY));
		}
	}
		
	public override void Die(){
		Debug.Log ("Eu morri!");
	}

}
