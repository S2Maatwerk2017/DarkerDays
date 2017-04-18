﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{

    //Adjustables
    [Header("Debugger")]
    [Tooltip("ENABLE TO SHOW RAYCAST AND SPAM THE CONSOLE WITH DATA")]
    public bool DEBUGMODE;
    [Header("Variables")]
    [Tooltip("The range at which the enemy must be compared to the player to do an action")]
    [Range(0, 20)]
    public float AggroRange;
    [Tooltip("The speed at which the enemy moves")]
    [Range(0, 7)]
    public float MoveSpeed;
    [Tooltip("The damage the enemy deals per hit")]
    [Range(0, 20)]
    public int Damage;
    [Tooltip("The amount of health given to the enemy")]
    public int MaxHealth;

    //soundlists
    public List<AudioClip> DeathSounds = new List<AudioClip>();
    public List<AudioClip> AttackSounds = new List<AudioClip>();
    public List<AudioClip> MoveSounds = new List<AudioClip>();

    public GameObject DamageNumber;

    //Hidden publics
    [HideInInspector] public Vector3 targetdirection { get { return Player.transform.position - this.transform.position; } }
    [HideInInspector] public GameObject Player;
    [HideInInspector] public bool PlayerSpotted;

    //Private data
    private int CurrentHealth;
    private int timer;
    private float DistanceToPlayer { get { return Vector3.Distance(this.transform.position, Player.transform.position); } }

    //Bodyparts
    private Rigidbody MyRigidbody;
    private NavMeshAgent agent;

    public void Start()
    {
        Setup();
        AggroRange = Player.GetComponent<SphereCollider>().radius;
        CurrentHealth = MaxHealth;
    }

    public void Update()
    {
        StandardAI();
    }

    public void Setup()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        MyRigidbody = GetComponent<Rigidbody>();
        PlayerSpotted = false;
        agent = GetComponent<NavMeshAgent>();
    }

    private void PlayRandomCategorieSound(SoundsToPlay Soundstoplay)
    {
        List<AudioClip> Soundlist = null;

        switch (Soundstoplay)
        {
            case SoundsToPlay.Attack:
                Soundlist = AttackSounds;
                goto default;
            case SoundsToPlay.Death:
                Soundlist = DeathSounds;
                goto default;
            case SoundsToPlay.Move:
                Soundlist = MoveSounds;
                goto default;
            default:
                if (Soundlist != null)
                {
                    SFXManager.instance.PlaySingle(Soundlist);
                }
                break;
        }
    }


    public void MoveNav()
    {
        if (PlayerSpotted == true)
        {
            DoBehavior();
            if (Vector3.Distance(this.transform.position, Player.transform.position) > 7)
            {
                PlayerSpotted = false;
            }
        }
        else if (timer >= 120)
        {
            moveRandom();
            timer = 0;
        }
        timer++;
    }

    public void StandardAI()
    {
        if (PlayerSpotted == true)
        {
            DoBehavior();
        }
        else
        {
            MoveNav();
        }
    }

    private void moveRandom()
    {
        int x = (int)Random.Range(-3, 3);
        int z = (int)Random.Range(-3, 3);

        Vector3 NextLocation = this.transform.position;
        NextLocation.x += (x * MoveSpeed);
        NextLocation.z += (z * MoveSpeed);

        agent.SetDestination(NextLocation);
        PlayRandomCategorieSound(SoundsToPlay.Move);
    }

    public virtual void DoBehavior()
    {
        RunToPlayer();
    }

    public void RunFromPlayer()
    {

        if (DistanceToPlayer >= AggroRange)
        {
            Attack();
            agent.SetDestination(this.transform.position);
            if (DistanceToPlayer >= AggroRange + 1)
            {
                PlayerSpotted = false;
            }
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(transform.position - Player.transform.position);
            Vector3 runTo = transform.position + transform.forward * 2.5f;
            agent.SetDestination(runTo);
        }
    }

    public void RunToPlayer()
    {
        if (DistanceToPlayer <= 1)
        {
            Attack();
            agent.SetDestination(this.transform.position);
            PlayRandomCategorieSound(SoundsToPlay.Move);
        }
        else
        {
            agent.SetDestination(Player.transform.position);
            PlayRandomCategorieSound(SoundsToPlay.Move);
        }
        if (DistanceToPlayer >= AggroRange + 1.0f)
        {
            PlayerSpotted = false;
        }
    }

    public virtual void Attack()
    {
        //Let each underlaying class implement their own variant.
        Debug.Log("Attack not implemented");
        PlayRandomCategorieSound(SoundsToPlay.Attack);
    }


    private void DoRayCast()
    {

        RaycastHit hit;
        Physics.Raycast(this.transform.position, targetdirection, out hit);
        if (DEBUGMODE == true)
        {
            Debug.DrawRay(transform.position, targetdirection, Color.red);
        }
        if (hit.transform.gameObject.tag == "Player")
        {
            Debug.Log("PLAYER SPOTTED! ATTACK!");
            //PlayerSpotted = true;
        }
        else
        {
            Debug.Log("Wall spotted");
            //PlayerSpotted = false;
        }
    }

    public void PlayerIsSpotted()
    {
        PlayerSpotted = true;
    }

    public void TakeDamage(int value)
    {
        CurrentHealth -= value;
        if (CurrentHealth <= 0)
        {
            PlayRandomCategorieSound(SoundsToPlay.Death);
            Destroy(gameObject);
        }
    }

    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }
}
