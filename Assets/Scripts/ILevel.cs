using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Level {

    int XP { get; set; }
    int MaxHealth { get; set; }
    int Lvl { get; set; }


    void BepaalLvl();
    void BepaalMaxHealth();
    void GainXP(int Amount);



}
