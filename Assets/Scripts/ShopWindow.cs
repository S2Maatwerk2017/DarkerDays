using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class ShopWindow : MonoBehaviour
    {
        public Text ItemName;
        public Text ItemCost;
        public Text ItemAmount;

        public GameObject ShopDialog;

        public MovemnetPlayerController playermovement;

        public Shop Shop { get; private set; }
        public Player Player { get; private set; }



        void Start()
        {
            if(ShopDialog == null)
            {
                ShopDialog = GameObject.Find("ShopWindow");
            }
            Debug.Log("dialogbox start");
            //SetDialogBox(false);
        }

        void Update()
        {
            
        }

        public ShopWindow()
        {
            Shop = new Shop();
        }
        
        private void CreateGUI()
        {
            ItemCost.text = Shop.Items.First().Price + "g";
            ItemAmount.text = Shop.Items.First().Amount + "x";
            ItemName.text = Shop.Items.First().Name;
        }

        public void SetDialogBox(bool value)
        {
            Debug.Log(ShopDialog.ToString() + "hey hey");
            ShopDialog.SetActive(value);
            if (!value)
            {
                playermovement.canMove = true;
            }
            else
            {
                playermovement.canMove = false;
            }
        }
    }
}
