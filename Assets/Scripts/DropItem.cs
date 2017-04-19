using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject dropBag;
    public GameObject prefab;
    public Player_Inventory Inventory;
    public PlayerAI player = new PlayerAI();
    public Item dropItem;
	// Use this for initialization
	void Start ()
	{
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyUp(KeyCode.K))
	    {
	        DropItemFunction(1);
	    }
	}

    void DropItemFunction(int itemID)
    {
        Inventory.ItemsList.Remove(Inventory.GetItemByID(itemID));
        
    }
}
