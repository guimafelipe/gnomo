using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy {
	
	void TryToMove();

	void TakeDamage(int dmg);

	void Die();

	void SetNewPosition(Spot spot);

	void SetPositionCoord (int x, int y);

}
