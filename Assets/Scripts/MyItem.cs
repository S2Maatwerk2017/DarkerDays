using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyItem : MonoBehaviour {

    public int InventorySlot;
    public string Name;
    public int Heal;
    public string Description;
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

    public string[] GetData()
    {
        string[] Data = new string[3];
        Data[0] = this.Name;
        Data[1] = this.Description;
        Data[2] = this.Heal.ToString();

        return Data;
    }
}
