using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class HP_Item : Item
    {
        public int HPGain { get; private set; }

        public HP_Item(int itemID,string name, int price, string description, int amount, string tag,  int hpGain) : base(itemID, name, price, description, amount, tag)
        {
            this.HPGain = hpGain;
        }

        public HP_Item()
        {
            
        }



    }
}
