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
        public List<AudioClip> inventorysound;

        void Start()
        {
            InventoryDisplay = GameObject.FindGameObjectWithTag("InventoryPanel");
        }

        void Update()
        {
            //Debug.Log(isShowing);

            if (Input.GetKeyDown(KeyCode.I))
            {
                isShowing = !isShowing;
                InventoryDisplay.SetActive(isShowing);
                SFXManager.Instance.RandomizeSfx(inventorysound);
            }
        }

    }
}
