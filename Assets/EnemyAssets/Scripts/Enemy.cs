using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    [Header("Debugger")]
    [Tooltip("ENABLE TO SHOW RAYCAST AND SPAM THE CONSOLE WITH DATA")]
    public bool DEBUGMODE;
    [Header("Variables")]
    public bool MoveOrFlee;
    [Tooltip("The range at which the enemy must be compared to the player to do an action")]
    [Range(0,20)]
    public float AggroRange;
    [Tooltip("The speed at which the enemy moves")]
    [Range(0,7)]
    public float MoveSpeed;
    [Tooltip("The damage the enemy deals per hit")]
    [Range(0,20)]
    public int Damage;

    public float TimeBetweenMove;
    public float TimeToMove;

    private float DistanceToPlayer { get { return Vector3.Distance(this.transform.position, Player.transform.position); } }

    public GameObject Player;
    public bool PlayerSpotted;
    private Rigidbody MyRigidbody;
    private bool moving;
    private Vector3 moveDirection;
    private float TimeBetweenMoveCounter;
    private float TimeToMoveCounter;

    private NavMeshAgent agent;
    private int timer;

    public void Start()
    {
        Setup();
        AggroRange = Player.GetComponent<SphereCollider>().radius;
    }

    public void Update()
    {
        StandardAI();
    }

    public void Setup()
    {
        Player = GameObject.Find("Player");
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
        if (DistanceToPlayer <= 1)
        {
            Attack();
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
        Vector3 targetdirection = Player.transform.position - this.transform.position;
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

    /*

    private void Move()
    {
        //If Player has been spotted, call the virtual Behavior method. (standard run away/ go to player)
        if (PlayerSpotted)
        {
            float DistanceToPlayer = Vector3.Distance(Player.transform.position, this.transform.position);
            if (DistanceToPlayer > 1)
            {
                DoBehavior();
            }

            //Check if the enemy is x distance away from the player, if so, stop using the playerspotted behavior.
            if (DistanceToPlayer > AggroRange)
            {
                PlayerSpotted = false;
            }
        }

        //If player has not been spotted, move in a random direction.
        else
        {
            //If the enemy is moving, allow the enemy walk for x amount of time (TimeToMoveCounter) before resetting.
            if (moving)
            {
                Debug.Log("Moving on");
                TimeToMoveCounter -= Time.deltaTime;
                MyRigidbody.velocity = moveDirection;

                //If the counter reaches zero, reset moving and calculate a wait timer.
                if (TimeToMoveCounter < 0)
                {
                    moving = false;
                    TimeBetweenMoveCounter = Random.Range(TimeBetweenMove * 0.75f, TimeBetweenMove * 1.25f);
                }
            }

            //If the enemy is not moving, wait x amount of time (TimeBetweenMoveCounter) before assigning a new location and timer.
            else
            {
                TimeBetweenMoveCounter -= Time.deltaTime;
                MyRigidbody.velocity = Vector3.zero;

                //If timer is lower than 0, assign a new location and timer.
                if (TimeBetweenMoveCounter < 0)
                {
                    moving = true;
                    TimeToMoveCounter = Random.Range(TimeToMove * 0.75f, TimeToMove * 1.25f);

                    moveDirection = new Vector3(Random.Range(-1f, 1f) * MoveSpeed, Random.Range(-1f, 1f) * MoveSpeed, 0f);

                }
            }

        }
    }
    
    public virtual void DoBehavior()
    {
        int speed = 0;
        if (MoveOrFlee)
        {
            speed = (int)MoveSpeed;
        }
        else if (!MoveOrFlee)
        {
            speed = (int)-MoveSpeed;
        }
        Vector3 Location = GetNextLocation(speed);
        transform.position = Location;
    }

    private Vector3 GetNextLocation(float Speed)
    {
        Vector3 PlayerLocation = Player.transform.position;
        Vector3 MyLocation = this.transform.position;
        return Vector3.MoveTowards(MyLocation, PlayerLocation, Speed * Time.deltaTime);
    }

*/
    public void PlayerIsSpotted()
    {
        PlayerSpotted = true;
    }
}
