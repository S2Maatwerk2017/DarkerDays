using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public List<Item> InventoryItems = new List<Item>();
    public List<GameObject> InventorySlots = new List<GameObject>();

    private Player_Inventory playerInventory;

    private int slotAmount;
    private GameObject InventoryPanel;
    private GameObject SlotPanel;
    public GameObject InventorySlot;
    public GameObject InventoryItem;

	// Use this for initialization
	void Start ()
	{
	    playerInventory = GetComponent<Player_Inventory>();

	    slotAmount = playerInventory.Items().Count;
	    InventoryPanel = GameObject.Find("Inventory Panel");
	    SlotPanel = InventoryPanel.transform.FindChild("Slot Panel").gameObject;

	    for (int i = 0; i < slotAmount; i++)
	    {
            InventoryItems.Add(new HP_Item());
	        InventorySlots.Add(Instantiate(InventorySlot));
            InventorySlots[i].transform.SetParent(SlotPanel.transform);
            
	    }

        foreach (Item i in playerInventory.Items().ToList())
        {
            AddItem(i.ItemID);
        }
        //AddItem(1);
        //AddItem(2);
        //AddItem(3);
        //AddItem(4);
        //AddItem(5);
    }
	
	// Update is called once per frame
	void Update ()
    {
		Debug.Log(InventoryItems.Count);
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
}
