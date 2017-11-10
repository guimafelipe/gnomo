using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GnomoBase : MonoBehaviour, IEnemy {

	protected int hp;
	public int maxHp = 1;

	public int posX, posY;
	public int nSteps = 1;

	public LevelMap lvlMap;

	public abstract void TryToMove();

	public abstract void Die ();

	public void SetNewPosition(Spot newSpot){
		this.transform.position = newSpot.transform.position;
		newSpot.SetGnomoInSpot (this);
	}

	public void SetPositionCoord(int x, int y){
		posX = x; posY = y;
	}

	public void TakeDamage(int dmg){
		hp -= dmg;
		if(hp <= 0){
			//die here
			Die();
		}
	}
}
