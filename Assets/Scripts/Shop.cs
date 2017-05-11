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
            new HP_Item(1, "Banana", 10, "Regenerates health with 2 hp", 2, "Banana", 2),
            new HP_Item(1, "Banana", 20, "Regenerates health with 2 hp", 5, "Banana", 2)
        };
        Debug.Log("Shop aangemaakt met " + Convert.ToString(Items.Count) + Items);
    }

    //TODO Player Koopt een item van shop
    public Item BuyItem(int indexOfItem)
    {
        Item boughtItem = Items[indexOfItem];
        return boughtItem;
    }

    ////TODO Verkoop een item
    //public void SellItem(Item item)
    //{
        
    //}
}
