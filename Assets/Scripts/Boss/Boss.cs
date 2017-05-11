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

    public List<AudioClip> BossBGM;

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
            if (SFXManager.Instance.TempBGM.clip != BossBGM[1])
            {
                SFXManager.Instance.PlayDifferentBMG(BossBGM[1]);
            }
        }
        else
        {
            BossManager.GetComponent<BossManager>().SpawnEnemies(true);
            if (SFXManager.Instance.TempBGM.clip != BossBGM[0])
            {
                SFXManager.Instance.PlayDifferentBMG(BossBGM[0]);
            }
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
                SFXManager.Instance.PlayDefaultBMG();
                return true;
            }
        }
        return false;
    }
}

