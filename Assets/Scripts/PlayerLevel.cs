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

    public void bepaalLevel()
    {
        if (XP >= 100)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        Lvl = Lvl + 1;
        XP = XP - 100;

        HealthManager.playerMaxHealth += 5;
        HealthManager.playerCurrentHealth += 5;
    }

    public void gainXP(int ammount)
    {
        XP = XP + ammount;
        Debug.Log(XP);
        bepaalLevel();
        Debug.Log(Lvl);
    }

}
