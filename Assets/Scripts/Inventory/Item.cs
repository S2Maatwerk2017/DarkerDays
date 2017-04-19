using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item:MonoBehaviour
{
    public Player_Inventory PlayerInventory = new Player_Inventory();
    abstract public int ItemID { get; set; }
    abstract public string Name { get; set; }
    abstract public int Price { get; set; }
    abstract public string Description { get; set; }
    abstract public int Amount { get; set; }
    abstract public string Tag { get; set; }
    abstract public Sprite Sprite { get; set; }

    public Item(int itemID,string name, int price, string description, int amount, string tag)
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
