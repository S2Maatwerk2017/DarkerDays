using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public int ItemID { get; private set; }
    public string Name { get; private set; }
    public int Price { get; private set; }
    public string Description { get; private set; }
    public int Amount { get; private set; }
    public string Tag { get; private set; }
    public Sprite Sprite { get; private set; }


    public Item(int itemID, string name, int price, string description, int amount, string tag)
    {
        this.ItemID = itemID;
        this.Name = name;
        this.Price = price;
        this.Description = description;
        this.Amount = amount;
        this.Tag = tag;
        this.Sprite = Resources.Load<Sprite>(tag);
    }

    public Item()
    {
        this.ItemID = -1;
    }

    public abstract void OnCollisionEnter(Collision collision);
}
