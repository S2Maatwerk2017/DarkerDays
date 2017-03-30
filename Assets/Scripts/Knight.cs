using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Enemy, IStrategy {

    private int Timer = 0;
    public override void DoBehavior()
    {
        base.RunToPlayer();
    }

    public override void Attack()
    {
        if (Timer >= 60)
        {
            Player.GetComponent<PlayerAI>().TakeDamage(Damage);
            Timer = 0;
        }
        Timer++;
    }
}
