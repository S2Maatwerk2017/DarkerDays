using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class GetItemFromChest : MonoBehaviour {

    private Inventory pi;
    public bool ChestOpened = false;
    int index;
    

    private Item RandomItem()
    {
        
        ////aan gezien er nog geen Items zijn aangemaakt zal dit een test Item zijn
        //HP_Item TestItem = new HP_Item(1, "test", 20, "test hp item", 1, "test tag", 10);

        index = Random.Range(0, pi.InventoryItems.Count);

        return pi.InventoryItems[index];
    }

    public void addRandomItemsToInventory(Inventory inventory)
    {
        ChestOpened = true;
        this.pi = inventory;
        inventory.InventoryItems.Add(RandomItem());
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.isTrigger == false)
        {
            if (this.ChestOpened == false)
            {
                
                RecieveItemFromAChest(other.GetComponent<Inventory>());
            }
        }
    }

    public void RecieveItemFromAChest(Inventory inventory)
    {

        this.addRandomItemsToInventory(inventory);
        Debug.Log(inventory.InventoryItems[5]);


    }



}
