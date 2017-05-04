using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;

public class Boss : Enemy, IStrategy
{
    public GameObject BossManager;
    public bool BossMayAggro = false;
    public override void Setup()
    {
        BossManager = GameObject.Find("BossManager");
        base.Setup();
    }

    public override void DoBehavior()
    {
        if(BossMayAggro)
        {
            base.RunToPlayer();
            BossManager.GetComponent<BossManager>().SpawnEnemies(false);

        }
        else
        {
            BossManager.GetComponent<BossManager>().SpawnEnemies(true);
        }
    }

    public override void StandardAI()
    {
        DoBehavior();
    }


    public override void Attack()
    {
        if (!Player.GetComponent<PlayerHealthManager>().iFramesActive)
        {
            Player.GetComponent<PlayerHealthManager>().HurtPlayer(Damage);
            var clone = (GameObject)Instantiate(DamageNumber, Player.GetComponent<Transform>().position + new Vector3(0f, 2f, 0.5f),
                    Quaternion.Euler(90f, 0f, 0f));
            clone.GetComponent<DamageNumbers>().damageNumber = Damage;
            base.Attack();
        }
    }

    public override bool TakeDamage(int value)
    {
        if (!BossMayAggro)
        {
            //Insert sound indicating that the boss can't be hit?
        }
        else
        {
            if (base.TakeDamage(value))
            {
                BossManager.GetComponent<BossManager>().OpenGate();
                return true;
            }
        }
        return false;
    }
}

