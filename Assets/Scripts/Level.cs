using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    public int XP;
    public int Lvl;
    public int MaxHealth;

    public void BepaalLvl()
    {
        if (XP >= 100)
        {
            Lvl = Lvl + 1;
            XP = XP - 100;
        }
    }

    public void BepaalMaxHealth()
    {
        throw new NotImplementedException();
    }

    public void GainXP(int Amount)
    {
        XP = XP + Amount;
    }
}
