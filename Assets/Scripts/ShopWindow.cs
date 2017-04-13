using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class ShopWindow
    {
        public Shop Shop { get; private set; }
        public Player Player { get; private set; }

        public ShopWindow()
        {
            Shop = new Shop();
        }

        private void CreateGUI()
        {
            foreach (Item item in Shop.Items)
            {
                
            }
        }
    }
}
