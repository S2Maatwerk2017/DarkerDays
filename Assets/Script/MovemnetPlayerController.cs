using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovemnetPlayerController : MonoBehaviour
{
    public float MoveSpeed;
    private float seconds;
    private Rigidbody2D RB;
    private Animator ani;
    private bool playerMoving;
    [HideInInspector]public Vector2 lastMove;
    //HideInInspector verbert jouw public variabelen voor unity. 
    //zo kun je ze toch aanroepen in andere classes, mara word deze niet getoont in unity zelf


    // Use this for initialization
    void Start ()
    {
        seconds = 0;
        ani = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        playerMoving = false;
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            RB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * PlayerDodgeStart(), RB.velocity.y);
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            RB.velocity = new Vector2(RB.velocity.x, Input.GetAxisRaw("Vertical") * PlayerDodgeStart());
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }


        //Stopt het doorschuiven
        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            RB.velocity = new Vector2(0f, RB.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            RB.velocity = new Vector2(RB.velocity.x, 0f);
        }

        //animatie
        ani.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        ani.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        ani.SetBool("PlayerMoving", playerMoving);
        ani.SetFloat("LastMoveX", lastMove.x);
        ani.SetFloat("LastMoveY", lastMove.y);

        // Seconden bijhouden tussen de frames
        seconds += Time.deltaTime;
        
        //Dodge 
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
}
