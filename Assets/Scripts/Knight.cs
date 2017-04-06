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
        if (!Player.GetComponent<PlayerHealthManager>().iFramesActive)
        {
            Player.GetComponent<PlayerHealthManager>().HurtPlayer(Damage);
            var clone = (GameObject)Instantiate(DamageNumber, Player.GetComponent<Transform>().position + new Vector3(0f, 2f, 0.5f),
                    Quaternion.Euler(90f, 0f, 0f));
            clone.GetComponent<DamageNumbers>().damageNumber = Damage;
        }
    }
}
