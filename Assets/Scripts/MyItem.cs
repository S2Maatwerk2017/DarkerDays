using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyItem : MonoBehaviour {

    public int InventorySlot;
    public string Name;
    public int Heal;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int UseItem()
    {
        return Heal;
    }
}
