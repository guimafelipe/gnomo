using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnomo : MonoBehaviour {

	int hp;
	public int maxHp = 1;

	public int nSteps = 1;

	// Use this for initialization
	void Start () {
		hp = maxHp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(int dmg){
		hp -= dmg;
		if(hp <= 0){
			//die here
			Debug.Log("I died!");
		}
	}

	public void SetNewPosition(Transform newPosition){
		this.transform.position = newPosition.position;
	}

}
