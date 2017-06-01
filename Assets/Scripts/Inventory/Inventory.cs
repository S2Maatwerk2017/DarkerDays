using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using Assets.Scripts.Inventory;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class Inventory : MonoBehaviour
{

    public List<Item> InventoryItems = new List<Item>();
    public List<GameObject> InventorySlots = new List<GameObject>();
    public List<GameObject> ItemsOnMap = new List<GameObject>();

    //private Load_ItemList loadList;

    public List<Item> itemsList = new List<Item>();

    private GameObject InventoryPanel;
    private GameObject SlotPanel;
    public GameObject InventorySlot;
    public GameObject InventoryItem;

    public GameObject CurrentChosenSlot;
    public GameObject PickUpItem;

    public GameObject Player;

    // Use this for initialization
    void Start()
    {
        //loadList = GetComponent<Load_ItemList>();
        //slotAmount = Load_ItemList.Items().Count;
        InventoryPanel = GameObject.Find("Inventory Panel");
        SlotPanel = InventoryPanel.transform.FindChild("Slot Panel").gameObject;

        itemsList = Load_ItemList.Items();

        DoInventorySlots();

        Player = GameObject.FindGameObjectWithTag("Player");
        InventoryPanel.SetActive(false);

        //Debug.Log(itemsList.Count);

        //AddItem(1);
        //AddItem(2);
        //AddItem(3);
        //AddItem(4);
        //AddItem(5);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckSlots();
        }

        //Debug.Log(EventSystem.current.currentSelectedGameObject.name);
    }

    private void CheckSlots()
    {
        foreach (GameObject slot in InventorySlots)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(slot.GetComponent<RectTransform>(), Input.mousePosition))
            {
                CurrentChosenSlot = slot;
                foreach (GameObject _slot in InventorySlots)
                {
                    _slot.GetComponent<Image>().color = new Color(225, 225, 225);
                }
                slot.GetComponent<Image>().color = new Color(0, 0, 0);
                break;
            }
        }
        GameObject UseItemButton = GameObject.Find("UseItemBTN");
        GameObject DropItemButton = GameObject.Find("DropItemBTN");
        if (Player.gameObject.GetComponent<InventoryAppearScript>().isShowing)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(UseItemButton.GetComponent<RectTransform>(),
                    Input.mousePosition))
            {
                int Healthgained = CurrentChosenSlot.GetComponentInChildren<MyItem>().UseItem();
                this.GetComponent<PlayerHealthManager>().HealPlayer(Healthgained);
                RemoveFromInventory();
            }
            if (RectTransformUtility.RectangleContainsScreenPoint(DropItemButton.GetComponent<RectTransform>(),
                Input.mousePosition))
            {
                Vector3 Location = this.transform.position;
                Location.x -= 2f;
                Location.z -= 2f;
                var _item = Instantiate(PickUpItem, Location, PickUpItem.transform.rotation,
                    GameObject.Find("Items").transform);
                Debug.Log(_item.GetComponent<Item>().Name);
                RemoveFromInventory();
            }
        }
    }

    private void RemoveFromInventory()
    {
        InventoryItems.RemoveAt(CurrentChosenSlot.GetComponentInChildren<MyItem>().InventorySlot);
        DoInventorySlots();
    }
    

    private void DoInventorySlots()
    {
        foreach (GameObject gameObject in InventorySlots)
        {
            Destroy(gameObject);
        }
        InventorySlots.Clear();
        for (int i = 0; i < InventoryItems.Count(); i++)
        {
            InventorySlots.Add(Instantiate(InventorySlot));
            InventorySlots[i].transform.SetParent(SlotPanel.transform);
            if (InventoryItems[i].ItemID != -1)
            {
                GameObject itemobj = Instantiate(InventoryItem);
                itemobj.transform.SetParent(InventorySlots[i].transform);
                itemobj.GetComponent<Image>().sprite = InventoryItems[i].Sprite;
                itemobj.transform.position = Vector2.zero;
                itemobj.GetComponent<MyItem>().Heal = InventoryItems[i].GetHealthGain();
                itemobj.GetComponent<MyItem>().Name = InventoryItems[i].Name;
                itemobj.GetComponent<MyItem>().InventorySlot = i;
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

    public void AddNewItem(int Id)
    {
        foreach (Item item in itemsList)
        {
            if (item.ItemID == Id)
            {

                InventoryItems.Add(item);
                DoInventorySlots();
                break;
            }
        }
    }
}
