using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item 
{

    public string Name { get; private set; }
    public int Price { get; private set; }
    public string Description { get; private set; }
    public int Amount { get; private set; }

    public Item(string name, int price, string description, int amount)
    {
        this.Name = name;
        this.Price = price;
        this.Description = description;
        this.Amount = amount;
    }
}
