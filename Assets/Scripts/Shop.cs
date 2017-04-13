using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop
{
    public List<Item> Items { get; private set; }



    public Shop()
    {
        Items = new List<Item>();
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
