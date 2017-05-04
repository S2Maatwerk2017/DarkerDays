using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    public GameObject TextBox;
    public ShopKeeper Currentshopkeeper;
    public RandomNPC CurrentRandomNPC;
    public MovemnetPlayerController playermovement;
    public Text textToShow;
    public Text option1ToShow;
    public Text option2ToShow;
    private int optionsShown = 1;

    public int currentDialog;
    public int currentLine;
    public int endOfLine;
    public bool stopPlayerMovement;

    // Use this for initialization
    void Start()
    {
        Debug.Log("dialogbox start");
        TextBox = GameObject.Find("DialogBox");
        SetDialogBox(false);
        currentDialog = 0;
        endOfLine = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Currentshopkeeper.playerCollide)
        {
            SetEndOfLine((NPC)Currentshopkeeper);
            SetDialogBox(true);
            if (Input.GetKeyDown(KeyCode.N))
            {
                Debug.Log("+1");
                currentLine += 1;
            }
            if (currentLine >= endOfLine)
            {
                Currentshopkeeper.playerCollide = false;
                Debug.Log(currentLine);
                Debug.Log("Aantal lines " + Currentshopkeeper.Dialogs[currentDialog].Lines.Count);
                Debug.Log("AAntal dialog" + Currentshopkeeper.Dialogs.Count);
                Debug.Log(endOfLine);
                SetDialogBox(false);
                currentLine = 0;
            }
            else
            {
                textToShow.text = Currentshopkeeper.Dialogs[0].Lines[currentLine].Line;
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
            if (currentLine >= endOfLine || CurrentRandomNPC.AlreadySelectedCorrectOption(currentLine))
            {
                CurrentRandomNPC.playerCollide = false;
                SetDialogBox(false);
                currentLine = 0;
            }
            else
            {
                textToShow.text = CurrentRandomNPC.Dialogs[0].Lines[currentLine].Line;

                if (!CurrentRandomNPC.Dialogs[0].Lines[currentLine].HasOptions)
                {
                    option1ToShow.text = "";
                    option2ToShow.text = "";
                    option1ToShow.gameObject.SetActive(false);
                    option2ToShow.gameObject.SetActive(false);
                }
                else if (CurrentRandomNPC.Dialogs[0].Lines[currentLine].HasOptions && !CurrentRandomNPC.AlreadySelectedCorrectOption(currentLine) && optionsShown < CurrentRandomNPC.Dialogs[0].Lines.Count)
                {
                    option1ToShow.gameObject.SetActive(true);
                    option2ToShow.gameObject.SetActive(true);
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

                //als je optie 1 hebt geselecteerd
                else if (EventSystem.current.currentSelectedGameObject == option1ToShow.gameObject)
                {
                    CurrentRandomNPC.SelectOption(0);
                    currentLine += 1;
                    EventSystem.current.SetSelectedGameObject(null);
                }
                //als je optie 2 hebt geselecteerd
                else if (EventSystem.current.currentSelectedGameObject == option2ToShow.gameObject)
                {
                    CurrentRandomNPC.SelectOption(1);
                    currentLine += 1;
                    EventSystem.current.SetSelectedGameObject(null);
                }
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
            endOfLine = npc.Dialogs[currentDialog].Lines.Count;
        }
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
}
