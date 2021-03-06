﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovemnetPlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public float attackTime;

    private float seconds;
    private Rigidbody RB;
    //private Animator ani;
    public Animator ani { get; private set; }
    private bool playerMoving;
    [HideInInspector]
    public Vector3 lastMove;
    private bool playerMeleeAttacking;
    public bool playerRangedAttacking;
    public bool isPlayerRanged;
    public bool canMove = true;
    private float attackTimeCounter;
    private float CurrentMoveSpeed;
    public float DiagnalMoveSpeedMultiplier;

    private PlayerHealthManager PlayerHealth;

    private Wallet wallet;
    private PlayerLevel level;
    private Inventory inventory;
    GetItemFromChest chest = new GetItemFromChest();
    //HideInInspector verbert jouw public variabelen voor unity. 
    //zo kun je ze toch aanroepen in andere classes, mara word deze niet getoont in unity zelf


    // Use this for initialization
    void Start()
    {
        seconds = 0;
        ani = GetComponent<Animator>();
        RB = GetComponent<Rigidbody>();
        PlayerHealth = GetComponent<PlayerHealthManager>();
        wallet = GetComponent<Wallet>();
        level = GetComponent<PlayerLevel>();
        inventory = GetComponent<Inventory>();
        if (isPlayerRanged)
        {
            ani.SetBool("IsPlayerRanged", isPlayerRanged);
        }

    }

    // Update is called once per frame
    void Update()
    {
        playerMoving = false;

        if (playerMeleeAttacking != true)
        {

            //if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            //{
            //    //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            //    RB.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * PlayerDodgeStart(),0f, RB.velocity.z);
            //    playerMoving = true;
            //    lastMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            //}
            //if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            //{
            //    //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            //    RB.velocity = new Vector3(RB.velocity.x, 0f, Input.GetAxisRaw("Vertical") * PlayerDodgeStart());
            //    playerMoving = true;
            //    lastMove = new Vector3(0f, 0f, Input.GetAxisRaw("Vertical"));
            //}

            // als de speler niet mag bewegen doe niks.
            if (canMove)
            {
                //lopen werkend!!
                //var HorSpeed = Input.GetAxis("Horizontal") * PlayerDodgeStart();
                if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
                {
                    RB.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * CurrentMoveSpeed, 0f, RB.velocity.z);
                    playerMoving = true;
                    lastMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
                //var VerSpeed = Input.GetAxis("Vertical") * PlayerDodgeStart();
                if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
                {
                    RB.velocity = new Vector3(RB.velocity.x, 0f, Input.GetAxisRaw("Vertical") * CurrentMoveSpeed);
                    playerMoving = true;
                    lastMove = new Vector3(0f, 0f, Input.GetAxisRaw("Vertical"));
                }

                //RB.velocity = new Vector3(HorSpeed, 0f, VerSpeed);
                //transform.Translate(HorSpeed, VerSpeed, 0f);

                // Stopt het doorschuiven
                if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
                {
                    RB.velocity = new Vector3(0f, 0f, RB.velocity.z);
                    //transform.position = transform.position;
                }
                if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
                {
                    RB.velocity = new Vector3(RB.velocity.x, 0f, 0f);
                    //transform.position = transform.position;
                }

                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
                {
                    CurrentMoveSpeed = MoveSpeed * DiagnalMoveSpeedMultiplier;
                }
                else
                {
                    CurrentMoveSpeed = MoveSpeed;
                }

                // Kijken of space ingedrukt wordt voor een aanval
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    attackTimeCounter = attackTime;
                    playerMeleeAttacking = true;
                    RB.velocity = Vector3.zero;
                    ani.SetBool("PlayerMeleeAttacking", true);
                // SFXManager.instance.PlaySingle(GetComponent<AudioSource>().clip);
                }
            }
            else
            {
                RB.velocity = new Vector3();
            }

        }

        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter < 0)
        {
            playerMeleeAttacking = false;
            ani.SetBool("PlayerMeleeAttacking", false);
        }

        //animatie
        ani.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        ani.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        ani.SetBool("PlayerMoving", playerMoving);
        ani.SetFloat("LastMoveX", lastMove.x);
        ani.SetFloat("LastMoveY", lastMove.z);

        // Seconden bijhouden tussen de frames
        seconds += Time.deltaTime;

        // Dodge 
        if (MoveSpeed == 5)
        {
            PlayerDodgeStart();
        }
        if (MoveSpeed >= 10)
        {
            PlayerDodgeStop();
        }
    }

    //Starten van het ontwijken kan alleen als de game langer dan 1 seconden bezig is.
    //En de snelheid van de speler lager is als 10.
    //Na het uitvoeren van deze methode is de snelheid van de speler verdubbeld en worden de seconden gereset naar 0.
    public float PlayerDodgeStart()
    {
        if (seconds > 1)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                MoveSpeed = MoveSpeed * 2;
                seconds = 0;
            }
        }
        return MoveSpeed;
    }

    //Eindigen van het ontwijken. Gebeurt een halve seconden nadat PlayerDodgeStart is aangeroepen.
    //De snelheid wordt teruggezet naar normaal en de seconden worden weer gereset naar 0.
    public float PlayerDodgeStop()
    {
        if (seconds > 0.3)
        {
            MoveSpeed = MoveSpeed / 2;
            seconds = 0;
        }
        return MoveSpeed;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().PlayerIsSpotted();
        }

    }


    public void IncreaseGold(int IncreaseGold)
    {
        wallet.GainGold(IncreaseGold);
    }

    public void IncreaseXP(int increaseXP)
    {
        level.gainXP(increaseXP);
    }

    public void SetFullHealth()
    {
        PlayerHealth.SetMaxHealth();
    }

    public string ToStringGold()
    {
        return "Gold: " + Convert.ToString(wallet.Gold);
    }

}
