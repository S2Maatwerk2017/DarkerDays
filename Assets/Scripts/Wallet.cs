using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour {

    public int Gold;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GainGold(int GainGold)
    {
        Gold = Gold + GainGold;
        Debug.Log(Gold);
    }

    public bool PayGold(int gold)
    {
        if (EnoughMoney(gold))
        {
            Gold -= gold;
            return true;
        }
        return false;
    }

    private bool EnoughMoney(int gold)
    {
        int geld = Gold;
        if (geld - gold < 0)
        {
            return false;
        }
        return true;
    }
}
