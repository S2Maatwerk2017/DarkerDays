using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<Item> Items { get; private set; }

	// Use this for initialization
	void Start ()
    {
		Items = new List<Item>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    //TODO Koop een item
    public Item BuyItem(int indexOfItem)
    {
        Item boughtItem = Items[indexOfItem];
        return boughtItem;
    }

    //TODO Verkoop een item
    public void SellItem(Item item)
    {
        
    }
}
