using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ShopKeeper : NPC
    {
        public bool playerCollide;
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
            List<string> lines = new List<string>
            {
                "Hallo",
                "Welkom bij mijn shop",
                "Kijk rustig rond"
            };
            Dialogs.Add(new Dialog(lines));
        }

        public void OnCollisionEnter(Collision other)
        {
            if (other.collider.tag != "Player")
            {
                return;
            }
            Debug.Log("PlayerCollision geslaagd");
            playerCollide = true;
        }
    }
}
