using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class HP_Item : Item
    {
        public int HPGain { get; private set; }
        public HP_Item(string name, int price, string description, int amount, int hpgain) : base(name, price, description, amount)
        {
            this.HPGain = hpgain;
        }
    }
}
