using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class Shop
{
    public List<Item> Items { get; private set; }



    public Shop()
    {
        Items = new List<Item>()
        {
            new HpItem(10, "Banana", "Regenerates health with 2 hp", 5, 2)
        };
        Debug.Log("Shop aangemaakt met " + Convert.ToString(Items.Count) + Items);
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
