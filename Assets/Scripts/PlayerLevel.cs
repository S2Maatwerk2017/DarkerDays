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
<<<<<<< HEAD
            LevelUp();
=======
            Lvl = Lvl + 1;
            XP = XP - 100;
            return true;
>>>>>>> 4fbc87018c66d36f0dcfd191b769fe1a0ad220c7
        }
        return false;
    }

<<<<<<< HEAD
    private void LevelUp()
    {
        Lvl = Lvl + 1;
        XP = XP - 100;

        HealthManager.playerMaxHealth += 5;
        HealthManager.playerCurrentHealth += 5;
    }

    public void gainXP(int ammount)
=======
    public bool gainXP(int ammount)
>>>>>>> 4fbc87018c66d36f0dcfd191b769fe1a0ad220c7
    {
        XP = XP + ammount;
        Debug.Log(XP);
        return bepaalLevel();
    }

}
