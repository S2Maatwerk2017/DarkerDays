using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;

public class Shop
{
    public List<Item> Items { get; private set; }


    //
    public Shop(List<Item> items)
    {
        Items = new List<Item>();
        Debug.Log("Er zijn " + items.Count + "items gevonden");
        foreach (Item item in items)
        {
            Debug.Log(item.ItemID);
        }
        Items.Add(items.First(item => item.ItemID == 1));
        Items.Add(items.First(item => item.ItemID == 12));
        Items.Add(items.First(item => item.ItemID == 4));
        Items.Add(items.First(item => item.ItemID == 17));
        Items.Add(items.First(item => item.ItemID == 16));
        Items.Add(items.First(item => item.ItemID == 8));
        Debug.Log("Shop aangemaakt met " + Convert.ToString(Items.Count) + "Items");
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
