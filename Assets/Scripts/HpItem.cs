using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class HpItem : Item
    {
        public int HitPointsRegeneration { get; private set; }
        public HpItem(int price, string name, string description, int amount, int hitpointsRegeneration) : base(price, name, description, amount)
        {
            HitPointsRegeneration = hitpointsRegeneration;
        }
    }
}
