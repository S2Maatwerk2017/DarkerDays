using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Player
{
    public class Wallet
    {
        public int gold;

        public void GainGold(int money)
        {
            gold = gold + money;
        }
    }
}
