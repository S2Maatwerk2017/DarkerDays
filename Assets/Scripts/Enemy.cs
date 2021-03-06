﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    //Adjustables
    [Header("Debugger")]
    [Tooltip("ENABLE TO SHOW RAYCAST AND SPAM THE CONSOLE WITH DATA")]
    public bool DEBUGMODE;
    [Header("Variables")]
    [Tooltip("The range at which the enemy must be compared to the player to do an action")][Range(0,20)]
    public float AggroRange;
    [Tooltip("The speed at which the enemy moves")][Range(0,7)]
    public float MoveSpeed;
    [Tooltip("The damage the enemy deals per hit")][Range(0,20)]
    public int Damage;
    [Tooltip("The amount of health given to the enemy")]
    public int MaxHealth;
    [Tooltip("Attack range of a melee enemy")][Range(0,10)]
    public float AttackRange;
    [Tooltip("Is this enemy part of a boss fight")]
    public bool IsBossEnemy;

    public GameObject DamageNumber;
    public GameObject DamageBurst;


    //Hidden publics
    [HideInInspector]public Vector3 targetdirection { get { return Player.transform.position - this.transform.position; } }
    [HideInInspector]public GameObject Player;
    [HideInInspector]public bool PlayerSpotted;

    //Private data
    private int CurrentHealth;
    private int timer;
    private float DistanceToPlayer { get { return Vector3.Distance(this.transform.position, Player.transform.position); } }

    //Bodyparts
    private Rigidbody MyRigidbody;
    private NavMeshAgent agent;
    private GameObject BossManager;
    private Wallet wallet = new Wallet();
    private PlayerLevel level = new PlayerLevel();

    public void Start()
    {
        Setup();
        AggroRange = Player.GetComponent<SphereCollider>().radius;
        CurrentHealth = MaxHealth;
        wallet.Gold = 5;
        level.XP = 25;
        if (IsBossEnemy)
        {
            BossManager = GameObject.Find("BossManager");
        }
    }

    public void Update()
    {
        StandardAI();
    }

    public virtual void Setup()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        MyRigidbody = GetComponent<Rigidbody>();
        PlayerSpotted = false;
        agent = GetComponent<NavMeshAgent>();
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
        else if(timer >= 120)
        {
            moveRandom();
            timer = 0;
        }
        timer++;
    }

    public virtual void StandardAI()
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
            if (DistanceToPlayer >= AggroRange+1)
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
        if (DistanceToPlayer <= AttackRange)
        {
            Attack();
            agent.SetDestination(this.transform.position);
        }
        else
        {
            agent.SetDestination(Player.transform.position);
        }
        if (DistanceToPlayer >= AggroRange+1.0f)
        {
            PlayerSpotted = false;
        }
    }

    public virtual void Attack() {
        //Let each underlaying class implement their own variant.
        Debug.Log("Attack not implemented");
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

    public virtual bool TakeDamage(int value)
    {
        CurrentHealth -= value;

        Instantiate(DamageBurst, transform.position, transform.rotation);
        var clone = (GameObject)Instantiate(DamageNumber, transform.position + new Vector3(0f, 2f, 0.5f), Quaternion.Euler(90f, 0f, 0f));
        clone.GetComponent<DamageNumbers>().damageNumber = value;

        if (CurrentHealth <= 0)
        {
            if (IsBossEnemy)
            {
                BossManager.GetComponent<BossManager>().EnemyWasKilled();
            }

            Destroy(gameObject);
            return true;
        }
        return false;
    }

    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }

    public int GetGold()
    {
        return wallet.Gold;
    }

    public int GetXP()
    {
        return level.XP;
    }
}
