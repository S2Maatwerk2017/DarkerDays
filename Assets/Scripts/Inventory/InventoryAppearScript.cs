using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
    public class InventoryAppearScript : MonoBehaviour
    {

        public GameObject InventoryDispaly;
        //Assign an inspector

        private bool isShowing;

        void Start()
        {

        }

        void Update()
        {
            Debug.Log(isShowing);
           
            if (Input.GetKeyDown(KeyCode.I))
            {
                isShowing = !isShowing;
                InventoryDispaly.SetActive(isShowing);
                
            }
        }

    }
}
