using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int Price { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Amount { get; private set; }

    public Item(int price, string name, string description)
    {
        Price = price;
        Name = name;
        Description = description;
    }

    public void SetAmount(int amount)
    {
        Amount = amount;
    }
}
