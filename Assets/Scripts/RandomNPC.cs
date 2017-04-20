using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomNPC : NPC {

    [Tooltip("The speed at which the enemy moves")]
    [Range(0, 7)]
    private int timer;

    public float MoveSpeed;

    private void Start()
    {

    }
    private void Update()
    {
        if (timer >= 120)
        {
            Move();
            timer = 0;
        }
        timer++;
    }

        private void Move()
    {
        int x = (int)Random.Range(-3, 3);
        int z = (int)Random.Range(-3, 3);

        Vector3 NextLocation = this.transform.position;
        NextLocation.x += (x * MoveSpeed);
        NextLocation.z += (z * MoveSpeed);

        agent.SetDestination(NextLocation);
    }
}