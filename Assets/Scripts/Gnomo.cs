using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnomo : MonoBehaviour, IGnomo{

	int hp;
	public int maxHp = 1;

	public int posX, posY;
	public int nSteps = 1;

	public LevelMap lvlMap;

	// Use this for initialization
	void Start () {
		hp = maxHp;
		lvlMap = GameObject.Find ("LevelMap").GetComponent<LevelMap>();
		SetNewPosition (lvlMap.GetSpot (1, 3));
		posX = 1; posY = 3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(int dmg){
		hp -= dmg;
		if(hp <= 0){
			//die here
			Die();
		}
	}


	//This method will be overrided for new types of gnomes. The below will work only for the base class gnome.
	public void TryToMove(){
		if (lvlMap.CheckIfSpotIsEmpty (posX, posY - 1)) {
			SetNewPosition (lvlMap.GetSpot (posX, --posY));
		} else {
			SetNewPosition (lvlMap.GetSpot (posX, posY));
		}
	}

	public void SetNewPosition(Spot newSpot){
		this.transform.position = newSpot.transform.position;
		newSpot.SetGnomoInSpot (this);
	}

	public void Die(){
		Debug.Log ("Eu morri!");
	}

}
