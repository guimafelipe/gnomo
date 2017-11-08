using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGnomo {
	
	void TryToMove();

	void TakeDamage(int dmg);

	void Die();

	void SetNewPosition(Spot spot);

}
