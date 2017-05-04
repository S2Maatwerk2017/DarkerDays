using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using Assets.Scripts.Inventory;


    public class HP_Item : Item
    {
        public int HPGain { get; private set; }

        public HP_Item(int itemID,string name, int price, string description, int amount, string tag,  int hpGain, int LocX, int LocY) : base(itemID, name, price, description, amount, tag,LocX, LocY)
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
                AddItemFromMapToList(this.ItemID, collision);
            }
        }

        public void AddItemFromMapToList(int itemID, Collision collision)
        {
            collision.transform.GetComponent<global::Inventory>().AddNewItem(itemID);
            this.gameObject.SetActive(false);
            //collision.transform.GetComponent<Inventory>().RefreshInventory();
        }

        public override void LoadNewData(Item item)
        {
            if (item is HP_Item) {
                HP_Item HPItem = (HP_Item)item;
                this.HPGain = HPItem.HPGain;
            }
            base.LoadNewData(item);
            
        }
    }

