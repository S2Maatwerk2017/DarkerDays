using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Inventory : MonoBehaviour {

    public List<Item> InventoryItems = new List<Item>();
    public List<GameObject> InventorySlots = new List<GameObject>();
    public List<GameObject> ItemsOnMap = new List<GameObject>();

    private Load_ItemList loadList;

    public List<Item> itemsList = new List<Item>();

    private int slotAmount;
    private GameObject InventoryPanel;
    private GameObject SlotPanel;
    public GameObject InventorySlot;
    public GameObject InventoryItem;
    public GameObject RandomItem;

    // Use this for initialization
    void Start ()
	{

        loadList = GetComponent<Load_ItemList>();

        slotAmount = loadList.Items().Count;
        InventoryPanel = GameObject.Find("Inventory Panel");
        SlotPanel = InventoryPanel.transform.FindChild("Slot Panel").gameObject;

	    itemsList = loadList.Items();

        for (int i = 0; i < slotAmount; i++)
        {
            InventoryItems.Add(new HP_Item());
            InventorySlots.Add(Instantiate(InventorySlot));
            InventorySlots[i].transform.SetParent(SlotPanel.transform);

        }

        foreach (Item i in itemsList.ToList())
        {
            AddItem(i.ItemID);
        }

        InventoryPanel.SetActive(false);

	    //Debug.Log(itemsList.Count);

        //AddItem(1);
        //AddItem(2);
        //AddItem(3);
        //AddItem(4);
        //AddItem(5);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //AddItemToList( item, InventoryItems);
    }

    public void AddItem(int id)
    {
        Item itemToAdd = playerInventory.GetItemByID(id);
        for (int i = 0; i < InventoryItems.Count; i++)
        {
            if (InventoryItems[i].ItemID == -1)
            {
                InventoryItems[i] = itemToAdd;
                GameObject itemobj = Instantiate(InventoryItem);
                itemobj.transform.SetParent(InventorySlots[i].transform);
                itemobj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                itemobj.transform.position = Vector2.zero;
                break;
            }
        }
    }

    void AddItemToList(Item item, List<Item> items)
    {
        if (!items.Contains(item))
        {
            items.Add(item);
        }
    }

    public void AddNewItem(Item item)
    {
        InventoryItems.Add(item);
    }
}
