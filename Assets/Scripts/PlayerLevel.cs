using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour {

    public int XP;
    public int Lvl;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool bepaalLevel()
    {
        if (XP >= 100)
        {
            Lvl = Lvl + 1;
            XP = XP - 100;
            return true;
        }
        return false;
    }

    public bool gainXP(int ammount)
    {
        XP = XP + ammount;
        Debug.Log(XP);
        return bepaalLevel();
    }

}
