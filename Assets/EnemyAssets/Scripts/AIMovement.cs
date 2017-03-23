using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour {

    [Header("Debugger")]
    [Tooltip("ENABLE TO SHOW RAYCAST AND SPAM THE CONSOLE WITH DATA")]
    public bool DEBUGMODE;
    [Header("Variables")]
    public float AggroRange;
    public bool MoveOrFlee;
    public float MoveSpeed;
    public float TimeBetweenMove;
    public float TimeToMove;


    private GameObject Player;
    private bool PlayerSpotted;
    private Rigidbody MyRigidbody;
    private bool moving;
    private Vector3 moveDirection;
    private float TimeBetweenMoveCounter;
    private float TimeToMoveCounter;
    

    void Start()
    {
        Player = GameObject.Find("Player");
        MyRigidbody = GetComponent<Rigidbody>();
        PlayerSpotted = false;
    }

    void Update()
    {
        DoRayCast();
        Move();
    }

    private void DoRayCast()
    {
        Vector3 targetdirection = Player.transform.position - this.transform.position;
        RaycastHit hit;
        Physics.Raycast(this.transform.position, targetdirection, out hit);
        float DistanceToPlayer = Vector3.Distance(this.transform.position, Player.transform.position);
        if (DEBUGMODE == true)
        {
            Debug.DrawRay(transform.position, targetdirection, Color.red);

            if (hit.transform.gameObject.tag == "Player" && DistanceToPlayer < AggroRange)
            {
                Debug.Log("PLAYER SPOTTED! ATTACK!");
                PlayerSpotted = true;
            }
            else
            {
                
                PlayerSpotted = false;
            }
        }

    }


    private void Move()
    {
        //If Player has been spotted, call the virtual Behavior method. (standard run away/ go to player)
        if (PlayerSpotted)
        {
            DoBehavior();

            //Check if the enemy is x distance away from the player, if so, stop using the playerspotted behavior.
            if (Vector3.Distance(Player.transform.position, this.transform.position) > AggroRange)
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


    public void PlayerIsSpotted()
    {
        PlayerSpotted = true;
    }
}
