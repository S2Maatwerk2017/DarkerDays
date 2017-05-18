using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ShopKeeper : NPC
    {
        public bool playerCollide = false;
        // Use this for initialization
        void Start()
        {
            Dialogs = new List<Dialog>();
            FillDialogList();
            Debug.Log("Shopkeeper start");
        }

        // Update is called once per frame
        void Update()
        {

        }

        //TODO Zet hier de tekst van de npc in.
        private void FillDialogList()
        {
            List<DialogLine> lines = new List<DialogLine>();
            lines.Add(new DialogLine("Hallo", false, false));
            lines.Add(new DialogLine("Welkom bij mijn shop", false, false));
            lines.Add(new DialogLine("Kijk rustig rond", false, false));
            Dialogs.Add(new Dialog(lines));
        }

        public void OnCollisionEnter(Collision other)
        {
            switch (other.collider.tag)
            {
                case "Player":
                {
                    Debug.Log("PlayerCollision geslaagd");
                    playerCollide = true;
                    break;
                }
            }
        }
    }
}
