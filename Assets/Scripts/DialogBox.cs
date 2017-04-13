using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    public GameObject TextBox;
    public ShopKeeper shopkeeper;
    public Text textToShow;

    public int currentDialog;
    public int currentLine;
    public int endOfLine;


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
        if (shopkeeper.playerCollide)
        {
            SetDialogBox(true);
            shopkeeper.playerCollide = false;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("+1");
            currentLine += 1;
        }
        if (currentLine >= endOfLine)
        {
            Debug.Log(currentLine);
            Debug.Log("Aantal lines " + shopkeeper.Dialogs[currentDialog].Lines.Count);
            Debug.Log("AAntal dialog" + shopkeeper.Dialogs.Count);
            Debug.Log(endOfLine);
            SetDialogBox(false);
            currentLine = 0;
        }
        else
        {
            textToShow.text = shopkeeper.Dialogs[0].Lines[currentLine];
        }
        if (shopkeeper != null)
        {
            SetEndOfLine();
        }
    }

    public void SetEndOfLine()
    {
        if (endOfLine == 0)
        {
            endOfLine = shopkeeper.Dialogs[currentDialog].Lines.Count;
        }
    }

    //Laat de dialog box zien of niet.
    public void SetDialogBox(bool value)
    {
        TextBox.SetActive(value);
    }
}
