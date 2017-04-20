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

    private void Start()
    {
        Dialogs = new List<Dialog>();
        FillDialogList();
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
        int x = (int)Random.Range(-3, 3);
        int z = (int)Random.Range(-3, 3);

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

                Debug.Log("in switch");
                playerCollide = true;
                //OpenShop();
                break;

        }
    }

    //TODO Zet hier de tekst van de npc in.
    private void FillDialogList()
    {
        List<string> lines = new List<string>();
        lines.Add("random text");
        lines.Add("Welkom in mijn wereld");
        Dialogs.Add(new Dialog(lines));
    }
}