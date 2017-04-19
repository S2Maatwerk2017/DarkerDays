using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class GetItemFromChest : MonoBehaviour {

    public bool ChestOpened = false;

    private Item RandomItem()
    {
        //aan gezien er nog geen Items zijn aangemaakt zal dit een test Item zijn
        HP_Item TestItem = new HP_Item("test", 20, "test hp item", 1, 10);



        return TestItem;
    }

    public void addRandomItemsToInventory(Inventory inventory)
    {
        ChestOpened = true;
        inventory.ListWithItems.Add(RandomItem());
    }



}
