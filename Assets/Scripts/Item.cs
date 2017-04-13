using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    public int Price { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Amount { get; private set; }

    public Item(int price, string name, string description, int amount)
    {
        Price = price;
        Name = name;
        Description = description;
        Amount = amount;
    }
}
