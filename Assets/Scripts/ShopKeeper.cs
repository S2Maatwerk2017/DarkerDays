using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class ShopKeeper : NPC
    {

        // Use this for initialization
        void Start ()
        {
            FillDialogList();
        }

        // Update is called once per frame
        void Update ()
        {
		    
        }

        //TODO Zet hier de tekst van de npc in.
        private void FillDialogList()
        {
            throw new NotImplementedException();
        }

        public void OnCollisionEnter(Collision other)
        {
            switch (other.collider.tag)
            {
                case "Player":
                {
                    ShowDialog();
                    OpenShop();
                    break;
                }
            }
        }

        private void OpenShop()
        {
            throw new NotImplementedException();
        }

        private void ShowDialog()
        {
            throw new NotImplementedException();
        }
    }
}
