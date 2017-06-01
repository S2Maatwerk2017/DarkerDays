using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;

public class Shop
{
    public List<Item> Items { get; private set; }

    public Shop(List<Item> items)
    {
        //Maak Items aan in shop
        Items = new List<Item>
        {
            items.First(item => item.ItemID == 1),
            items.First(item => item.ItemID == 12),
            items.First(item => item.ItemID == 4),
            items.First(item => item.ItemID == 17),
            items.First(item => item.ItemID == 16),
            items.First(item => item.ItemID == 8)
        };
        Debug.Log("Shop aangemaakt met " + Convert.ToString(Items.Count) + "Items");
    }
}
