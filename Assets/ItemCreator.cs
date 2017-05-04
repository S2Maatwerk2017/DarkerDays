﻿using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class ItemCreator : MonoBehaviour {

    //private Load_ItemList loadList;
    public List<Item> itemsList;
    public List<GameObject> CreatedItems;
    public GameObject PickUpItem;

    // Use this for initialization
    void Start () {

        //loadList = GetComponent<Load_ItemList>();
        itemsList = Load_ItemList.Items();
        PlaceItems();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void PlaceItems()
    {
        foreach (Item item in itemsList)
        {
            Vector3 Location = this.transform.position;
            Location.x += item.Location[0];
            Location.z += item.Location[1];
            PickUpItem.GetComponent<HP_Item>().LoadNewData(item);
            var _item = Instantiate(PickUpItem, Location, PickUpItem.transform.rotation);
        }
    }
}
