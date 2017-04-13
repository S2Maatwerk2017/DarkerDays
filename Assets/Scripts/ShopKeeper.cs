using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ShopKeeper : NPC
    {
        public bool playerCollide = false;
        // Use this for initialization
        void Start () 
        {
            Dialogs = new List<Dialog>();
            FillDialogList();
            Debug.Log("Shopkeeper start");
        }

        // Update is called once per frame
        void Update ()
        {
		    
        }

        //TODO Zet hier de tekst van de npc in.
        private void FillDialogList()
        {
            List<string> lines = new List<string>();
            lines.Add("Hallo");
            lines.Add("Doei");
            lines.Add("Wtf doe je hier nog????");
            lines.Add("Ga WEG!!!");
            lines.Add("Ik vind het niet leuk meer.");
            
            Dialogs.Add(new Dialog(lines));
        }

        public void OnCollisionEnter(Collision other)
        {
            switch (other.collider.tag)
            {
                case "Player":
                {
<<<<<<< HEAD
                    Debug.Log("PlayerCollision geslaagd");
                    ShowDialog();
                    OpenShop();
=======
                    playerCollide = true;
                    //OpenShop();
>>>>>>> Jethro_Branch
                    break;
                }
            }
        }

        private void OpenShop()
        {
            ShopWindow shopWindow = new ShopWindow();
        }
<<<<<<< HEAD

        private void ShowDialog()
        {
            OpenShop();
        }
=======
>>>>>>> Jethro_Branch
    }
}
