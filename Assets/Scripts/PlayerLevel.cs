using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour {

    public int XP;
    public int Lvl;
    public PlayerHealthManager HealthManager;

    // Use this for initialization
    void Start()
    {
        HealthManager = GetComponent<PlayerHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool bepaalLevel()
    {
        if (XP >= 100)
        {
            LevelUp();
            return true;
        }
        return false;
    }

    private void LevelUp()
    {
        Lvl = Lvl + 1;
        XP = XP - 100;

        HealthManager.playerMaxHealth += 5;
        HealthManager.playerCurrentHealth += 5;
    }

    public bool gainXP(int ammount)
    {
        XP = XP + ammount;
        Debug.Log(XP);
        return bepaalLevel();
    }

}
