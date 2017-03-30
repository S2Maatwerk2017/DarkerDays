using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Enemy, IStrategy {
    	

    public override void DoBehavior()
    {
        base.RunToPlayer();
    }

    public override void Attack()
    {
        Debug.Log("Knight Attack");
    }
}
