using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour {

    private Inventory Inventory = new Inventory();
    private PlayerAI Player = new PlayerAI();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void PickUPItem(Item item)
    {
        if (Input.GetKey(KeyCode.Q)&& Player.)
        {
            Inventory.ListWithItems.Add(item);
        }

    }
}
