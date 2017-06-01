using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
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
    public Text option1ToShow;
    public Text option2ToShow;
    private int optionsShown = 1;
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
    {   //als de shopkeeper collide met player.
        if (Currentshopkeeper.playerCollide)
        {
            if (CurrentRandomNPC.playerCollide)
            {
                CurrentRandomNPC.playerCollide = false;
            }
            //set options to show naar false
            option1ToShow.gameObject.SetActive(false);
            option2ToShow.gameObject.SetActive(false);
            SetEndOfLine((NPC)Currentshopkeeper);
            SetDialogBox(true);
            //als je op n drukt, laat de volgende line zien.
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
            //als je aan het einde bent van de dialogs, laat de dialogbox niet meer zien.
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
                textToShow.text = Currentshopkeeper.Dialogs[0].Lines[currentLine].Line;
            }
        }
        //als de currentrandomnpc met de player collide.
        if (CurrentRandomNPC.playerCollide)
        {
            if (Currentshopkeeper.playerCollide)
            {
                Currentshopkeeper.playerCollide = false;
            }
            SetEndOfLine((NPC)CurrentRandomNPC);
            SetDialogBox(true);
            if (Input.GetKeyDown(KeyCode.N))
            {
                if ((currentLine + 1) == 3)
                {
                    currentLine += 2;
                }
                else
                {
                    currentLine += 1;
                }
            }
            //als je bij het einde van de dialogs bent
            if (currentLine >= endOfLine)
            {
                CurrentRandomNPC.playerCollide = false;
                SetDialogBox(false);
                currentLine = 0;
            }
            else if (CurrentRandomNPC.AlreadySelectedCorrectOption(currentLine) && currentLine < endOfLine)
            {
                if ((currentLine + 1) == 3)
                {
                    currentLine += 2;
                }
                else
                {
                    currentLine += 1;
                }
            }
            else
            {   //laat de dialog text zien
                textToShow.text = CurrentRandomNPC.Dialogs[0].Lines[currentLine].Line;
                //als de dialog geen opties heeft, laat de optie boxen dan niet zien.
                if (!CurrentRandomNPC.Dialogs[0].Lines[currentLine].HasOptions)
                {
                    option1ToShow.text = "";
                    option2ToShow.text = "";
                    option1ToShow.gameObject.SetActive(false);
                    option2ToShow.gameObject.SetActive(false);
                }//als de dialog wel opties heeft en nog neit de correcte hebt geselecteerd en alle opties laat zien
                else if (CurrentRandomNPC.Dialogs[0].Lines[currentLine].HasOptions && !CurrentRandomNPC.AlreadySelectedCorrectOption(currentLine) && optionsShown < CurrentRandomNPC.Dialogs[0].Lines.Count)
                {
                    option1ToShow.gameObject.SetActive(true);
                    option2ToShow.gameObject.SetActive(true);
                    //voor elke optie
                    for (int i = 1; i <= CurrentRandomNPC.Options[0].Lines.Count; i++)
                    {
                        Debug.Log(i + " + " + optionsShown);
                        //als optie 1 gevuld is
                        if (option1ToShow.text != "")
                        {
                            Debug.Log("Option2 moet gevuld worden");
                            option2ToShow.text = CurrentRandomNPC.Options[0].Lines[i - 1].Line;
                            Debug.Log("option1: " + option1ToShow.text);
                            Debug.Log("option2: " + option2ToShow.text);
                        }
                        //als optie 2 niet gevuld is
                        else if (option2ToShow.text == "")
                        {
                            Debug.Log("option1 moet nu gevuld worden");
                            option1ToShow.text = CurrentRandomNPC.Options[0].Lines[i - 1].Line;
                            Debug.Log("option1: " + option1ToShow.text);
                            Debug.Log("option2: " + option2ToShow.text);
                        }
                        optionsShown++;
                    }
                }
                // als je optie 1 hebt geselecteerd
                //(dit is de correcte optie!!!! hier code inzetten om daadwerkelijk iets te doen.)
                else if (EventSystem.current.currentSelectedGameObject == option1ToShow.gameObject)
                {   //laat de speler geld betalen
                    if (playermovement.PayGold(CurrentRandomNPC.Dialogs[0].Lines[currentLine].GoldToPay))
                    {
                        CurrentRandomNPC.SelectOption(0);
                        //haal de inventory op en voeg een banaan toe.
                        Inventory inventory = (Inventory) playermovement.GetComponent(typeof(Inventory));
                        inventory.AddNewItem(1);
                        if ((currentLine + 1) == 3)
                        {
                            currentLine += 2;
                        }
                        else
                        {
                            currentLine += 1;
                        }
                    }
                    else
                    {
                        currentLine = 3;
                    }
                    EventSystem.current.SetSelectedGameObject(null);
                }
                //als je optie 2 hebt geselecteerd
                else if (EventSystem.current.currentSelectedGameObject == option2ToShow.gameObject)
                {
                    CurrentRandomNPC.SelectOption(1);
                    if ((currentLine + 1) == 3)
                    {
                        currentLine += 2;
                    }
                    else
                    {
                        currentLine += 1;
                    }
                    EventSystem.current.SetSelectedGameObject(null);
                }
            }
        }
    }

    public void SetEndOfLine(NPC npc)
    {
        if (npc is RandomNPC)
        {
            npc = (RandomNPC)npc;
        }
        else if (npc is ShopKeeper)
        {
            npc = (ShopKeeper)npc;
        }
            Debug.Log("Set End Of Line");
            endOfLine = npc.Dialogs[currentDialog].Lines.Count;
    }

    //Laat de dialog box zien of niet. zet de canMove van player op true of false.
    public void SetDialogBox(bool value)
    {
        TextBox.SetActive(value);
        if (!value)
        {
            playermovement.canMove = true;
            optionsShown = 1;
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
