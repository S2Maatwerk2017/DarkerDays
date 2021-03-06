﻿using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    public GameObject TextBox;
    public ShopKeeper Currentshopkeeper;
    public RandomNPC CurrentRandomNPC;
    public MovemnetPlayerController playermovement;
    public Text textToShow;

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
}
