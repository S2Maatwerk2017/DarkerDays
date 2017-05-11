using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.AI;

public class RandomNPC : NPC
{

    [Tooltip("The speed at which the enemy moves")]
    [Range(0, 7)]
    private int timer;

    public float MoveSpeed;
    public bool playerCollide = false;
    public List<Dialog> Options;

    //is -1 als er nog niets is geselecteerd, 0 voor eerste 1 voor tweede.
    public int SelectedOptionIndex = -1;

    private void Start()
    {
        Dialogs = new List<Dialog>();
        FillDialogList();
        FillOptionList();
    }

    private void FillOptionList()
    {
        Options = new List<Dialog>();
        List<DialogLine> options = new List<DialogLine>();
        options.Add(new DialogLine("Ja graag, die wasmachine is totaal niet te duur", false, true,5));
        options.Add(new DialogLine("Nee, wat moet ik met een wasmachine", false, false));
        Options.Add(new Dialog(options));
    }

    //Set Selected Option
    public void SelectOption(int index)
    {
        SelectedOptionIndex = index;
    }

    public bool AlreadySelectedCorrectOption(int currentLine)
    {
        if (SelectedOptionIndex != -1)
        {
            if (Options[0].Lines[SelectedOptionIndex].IsCorrectOption && Dialogs[0].Lines[currentLine].HasOptions)
            {
                return true;
            }
        }
        return false;
    }

    private void Update()
    {
        if (!playerCollide)
        {
            if (timer >= 120)
            {
                Move();
                timer = 0;
            }
            timer++;
        }
        else
        {
            DontMove();
            timer = 0;
        }

    }

    private void Move()
    {
        Vector3 NextLocation;
        Debug.Log("stop niet met lopen");
        int x = (int)UnityEngine.Random.Range(-3, 3);
        int z = (int)UnityEngine.Random.Range(-3, 3);

        NextLocation = this.transform.position;
        NextLocation.x += (x * MoveSpeed);
        NextLocation.z += (z * MoveSpeed);
        agent.SetDestination(NextLocation);
    }

    private void DontMove()
    {
        Vector3 NextLocation;
        Debug.Log("stop met lopen");
        NextLocation = this.transform.position;
        this.MyRigidbody.velocity = new Vector3();
        agent.SetDestination(NextLocation);
    }

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("in methode");
        switch (other.collider.tag)
        {
            case "Player":
                {
                    Debug.Log("in switch");
                    playerCollide = true;
                    //OpenShop();
                    break;
                }
        }
    }

    //TODO Zet hier de tekst van de npc in.
    private void FillDialogList()
    {
        List<DialogLine> lines = new List<DialogLine>();
        lines.Add(new DialogLine("random text", false, false));
        lines.Add(new DialogLine("Welkom in mijn wereld", false, false));
        lines.Add(new DialogLine("Wil je voor 5 gold een banaan kopen?", true, false, 5));
        lines.Add(new DialogLine("Nogmaals bedankt!",false,false));
        Dialogs.Add(new Dialog(lines));
    }
}