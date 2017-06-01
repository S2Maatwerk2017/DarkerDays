using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEditor;

public class DialogBox : MonoBehaviour
{
    public GameObject TextBox;
    public GameObject ShopTradeSlot;
    public GameObject ShopItemLayout;
    public ShopKeeper Currentshopkeeper;
    public RandomNPC CurrentRandomNPC;
    public MovemnetPlayerController playermovement;
    public Text textToShow;
    public Text TextItemName;
    public Text TextItemAmount;
    public Text TextItemCost;
    public Image ImageItemSprite;
    public GameObject ShopDialog;

    public bool ShopDialogAangemaakt = false;
    public int currentDialog;
    public int currentLine;
    public int endOfLine;
    public bool stopPlayerMovement;

    public List<GameObject> ShopItemLayouts;

    // Use this for initialization
    void Start()
    {
        ShopItemLayouts = new List<GameObject>();
        Debug.Log("dialogbox start");
        TextBox = GameObject.Find("DialogBox");
        //shopwindow = new ShopWindow();
        SetDialogBox(false);
        SetDialogShopBox(false);
        currentDialog = 0;
        endOfLine = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Currentshopkeeper != null)
        {
            SetEndOfLine(Currentshopkeeper);
        }
        if (Currentshopkeeper.playerCollide)
        {
            SetEndOfLine((NPC)Currentshopkeeper);
            SetDialogBox(true);
            if (Input.GetKeyDown(KeyCode.N))
            {
                if (currentLine == -1)
                {
                    Debug.Log("Exit Shop");
                    Currentshopkeeper.playerCollide = false;
                    SetDialogShopBox(false);
                    SetDialogBox(false);
                    currentLine = 0;
                    return;
                }
                Debug.Log("+1");
                currentLine += 1;

            }
            if (currentLine >= endOfLine)
            {
                Debug.Log(currentLine);
                Debug.Log("Aantal lines " + Currentshopkeeper.Dialogs[currentDialog].Lines.Count);
                Debug.Log("AAntal dialog" + Currentshopkeeper.Dialogs.Count);
                Debug.Log(endOfLine);
                SetDialogBox(false);
                SetDialogShopBox(true);
                currentLine = -1;
            }
            else if (currentLine > -1)
            {
                Debug.Log("Show new line");
                Debug.Log(currentLine);
                textToShow.text = Currentshopkeeper.Dialogs[0].Lines[currentLine];
            }
        }
        if (CurrentRandomNPC.playerCollide)
        {
            SetEndOfLine((NPC)CurrentRandomNPC);
            SetDialogBox(true);
            if (Input.GetKeyDown(KeyCode.N))
            {
                currentLine += 1;
            }
            if (currentLine >= endOfLine)
            {
                CurrentRandomNPC.playerCollide = false;
                SetDialogBox(false);
                currentLine = 0;
            }
            else
            {
                textToShow.text = CurrentRandomNPC.Dialogs[0].Lines[currentLine];
            }
        }
    }

    public void SetEndOfLine(NPC npc)
    {
        if (npc.GetType() == typeof(RandomNPC))
        {
            npc = (RandomNPC)npc;
        }
        else if (npc.GetType() == typeof(ShopKeeper))
        {
            npc = (ShopKeeper)npc;
        }
        if (endOfLine == 0)
        {
            Debug.Log("Set End Of Line");
            endOfLine = npc.Dialogs[currentDialog].Lines.Count;
        }
    }

    //Laat de dialog box zien of niet.
    public void SetDialogBox(bool value)
    {
        TextBox.SetActive(value);
        if (!value)
        {
            playermovement.canMove = true;
        }
        else
        {
            playermovement.canMove = false;
        }
    }

    public void SetDialogShopBox(bool value)
    {
        Debug.Log(ShopDialog.ToString() + "hey hey");
        ShopDialog.SetActive(value);
        if (!value)
        {
            playermovement.canMove = true;
        }
        else if (ShopDialogAangemaakt)
        {
            return;
        }
        else
        {
            Debug.Log("Maak Shop aan vanaf Dialog box");
            GameObject playerGameObject = GameObject.Find("MeleePlayer");
            List<Item> AllGameItems = Load_ItemList.Items();
            //Maak shop aan
            Shop shop = new Shop(AllGameItems);
            Debug.Log("De shop heeft " + shop.Items.Count + " trades.");
            ShopDialogAangemaakt = true;

            //Maak voor elk item een shopslot aan.
            foreach (Item item in shop.Items)
            {
                //Maak slot aan
                GameObject shopSlot = Instantiate(ShopTradeSlot);
                //Bepaal parent van gameobject
                shopSlot.transform.SetParent(ShopDialog.transform);

                //check of item valide is
                if (item.ItemID == -1)
                {
                    continue;
                }
                
                //Maak Item aan
                GameObject shopItem = Instantiate(ShopItemLayout);
                //Bepaal parent van gameobject
                shopItem.transform.SetParent(shopSlot.transform);


                Text shopItemName = Instantiate(TextItemName);
                shopItemName.transform.SetParent(shopItem.transform);
                shopItemName.text = item.Name;
                Text shopItemPrice = Instantiate(TextItemCost);
                shopItemPrice.transform.SetParent(shopItem.transform);
                shopItemPrice.text = item.Price + "g";
                Text shopItemAmount = Instantiate(TextItemAmount);
                shopItemAmount.transform.SetParent(shopItem.transform);
                shopItemAmount.text = item.Amount + "x";
                Image shopItemSprite = Instantiate(ImageItemSprite);
                shopItemSprite.transform.SetParent(shopItem.transform);
                shopItemSprite.sprite = item.Sprite;
            }
            TextItemCost.text = shop.Items.First().Price + "g";
            TextItemAmount.text = shop.Items.First().Amount + "x";
            TextItemName.text = shop.Items.First().Name;
            playermovement.canMove = false;
        }
    }
}
