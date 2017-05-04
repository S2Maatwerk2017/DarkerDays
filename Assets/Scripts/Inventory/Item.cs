using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public int ItemID;
    public string Name { get; private set; }
    public int Price { get; private set; }
    public string Description { get; private set; }
    public int Amount { get; private set; }
    public string Tag { get; private set; }
    public Sprite Sprite { get; private set; }

    public int[] Location { get; private set; }

    public Item(int itemID, string name, int price, string description, int amount, string tag, int LocX, int LocY)
    {
        Location = new int[2];
        this.ItemID = itemID;
        this.Name = name;
        this.Price = price;
        this.Description = description;
        this.Amount = amount;
        this.Tag = tag;
        this.Sprite = Resources.Load<Sprite>(tag);
        this.Location[0] = LocX;
        this.Location[1] = LocY;
    }

    public Item()
    {
        this.ItemID = -1;
    }

    public abstract void OnCollisionEnter(Collision collision);

    public virtual void LoadNewData(Item item)
    {
        ItemID = item.ItemID;
        Name = item.Name;
        Price = item.Price;
        Description = item.Description;
        Amount = item.Amount;
        Tag = item.Tag;
        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Tag);
        Location = item.Location;
    }
}
