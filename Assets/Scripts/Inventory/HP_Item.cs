using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class HP_Item : Item 
    {
        Player_Inventory pi = new Player_Inventory();
        public int HPGain { get; private set; }

        public override int ItemID { get { return this.ItemID; } set { } }
        public override string Name { get { return this.Name; } set{} }
        public override int Price { get { return this.Price; } set{} }
        public override string Description { get { return this.Description; } set{} }
        public override int Amount { get { return this.Amount; } set{} }
        public override string Tag { get { return this.Tag; } set {} }
        public override Sprite Sprite { get { return this.Sprite; } set {} }

        public int objectHpGain;
        public HP_Item(int itemID,string name, int price, string description, int amount, string tag,  int hpGain) : base(itemID, name, price, description, amount, tag)
        {
            this.HPGain = hpGain;
        }

        public HP_Item()
        {
            
        }

        public override void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Item item = new HP_Item(ItemID,Name,Price,Description,Amount,Tag,HPGain);
                pi.ItemsList.Add(item);
                this.gameObject.SetActive(false);
            }
        }
    }
}
