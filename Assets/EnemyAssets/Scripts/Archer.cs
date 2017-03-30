using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Enemy, IStrategy {

    private float Timer = 0;
	
    public override void DoBehavior()
    {
        base.RunFromPlayer();
    }

    public override void Attack()
    {
        Debug.Log("Archer Attack");
    }
}
