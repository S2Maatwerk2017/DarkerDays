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
        public int HPGain { get; private set; }
        
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
            Player_Inventory playerInventory = new Player_Inventory();
            if (collision.gameObject.tag == "Player")
            {
                if (this.gameObject.tag == "Banana")
                {
                    AddItemFromMapToList(1,collision);
                }

                else if(this.gameObject.tag == "Apple")
                {
                    AddItemFromMapToList(5,collision);
                }

                else if (this.gameObject.tag == "Cumcumber")
                {
                    AddItemFromMapToList(3,collision);
                }
            }
        }

        public void AddItemFromMapToList(int itemID, Collision collision)
        {
            collision.transform.GetComponent<Inventory>().AddNewItem(collision.transform.GetComponent<Player_Inventory>().GetItemByID(itemID));
            this.gameObject.SetActive(false);
            //collision.transform.GetComponent<Inventory>().RefreshInventory();
        }
    }
}
