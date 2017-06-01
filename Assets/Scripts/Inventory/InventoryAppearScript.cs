﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
    public class InventoryAppearScript : MonoBehaviour
    {

        public GameObject InventoryDisplay;
        //Assign an inspector

        public bool isShowing;

        void Start()
        {
            InventoryDisplay = GameObject.FindGameObjectWithTag("InventoryPanel");
        }

        void Update()
        {           
            if (Input.GetKeyDown(KeyCode.I))
            {
                isShowing = !isShowing;
                InventoryDisplay.SetActive(isShowing);
            }
        }

    }
}
