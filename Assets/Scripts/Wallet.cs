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

    public void PayGold(int gold)
    {
        Gold -= gold;
    }
}
