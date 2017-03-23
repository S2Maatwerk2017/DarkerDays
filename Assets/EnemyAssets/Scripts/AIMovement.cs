using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour {
    GameObject Player;
    public bool MoveOrFlee;
    private bool PlayerSpotted;

    public float MoveSpeed;
    private Rigidbody rigidbody;

    /**/
    private bool moving;
    private Vector3 moveDirection;
    public float TimeBetweenMove;
    private float TimeBetweenMoveCounter;
    public float TimeToMove;
    private float TimeToMoveCounter;
    /**/

    void Start()
    {
        Player = GameObject.Find("Player");
        rigidbody = GetComponent<Rigidbody>();
        PlayerSpotted = false;
    }

    void Update()
    {
        DoRayCast();
        Move();
    }

    private void DoRayCast()
    {
        Vector3 targetLocation = Player.transform.position - this.transform.position;
        RaycastHit hit;
        Debug.Log(Physics.Raycast(this.transform.position, targetLocation, out hit));
        Debug.DrawRay(transform.position, targetLocation, Color.red);

    }


    private void Move()
    {
        if (PlayerSpotted)
        {
            if (MoveOrFlee)
            {
                MoveToPlayer();
            }
            else if (!MoveOrFlee)
            {
                RunFromPlayer();
            }
            if (Vector3.Distance(Player.transform.position, this.transform.position) > 8)
            {
                PlayerSpotted = false;
            }
        }
        else
        {
            if (moving)
            {
                TimeToMoveCounter -= Time.deltaTime;
                rigidbody.velocity = moveDirection;

                if (TimeToMoveCounter < 0)
                {
                    moving = false;
                    TimeBetweenMoveCounter = Random.Range(TimeBetweenMove * 0.75f, TimeBetweenMove * 1.25f);
                }
            }
            else
            {
                TimeBetweenMoveCounter -= Time.deltaTime;
                rigidbody.velocity = Vector3.zero;

                if (TimeBetweenMoveCounter < 0)
                {
                    moving = true;
                    TimeToMoveCounter = Random.Range(TimeToMove * 0.75f, TimeToMove * 1.25f);

                    moveDirection = new Vector3(Random.Range(-1f, 1f) * MoveSpeed, Random.Range(-1f, 1f) * MoveSpeed, 0f);

                }
            }

        }
    }

    private void MoveToPlayer()
    {
        Vector3 Location = GetNextLocation(3);
        transform.position = Location;
    }

    private void RunFromPlayer()
    {
        Vector3 Location = GetNextLocation(-3);
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
