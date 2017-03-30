using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public Player player;
    private Rigidbody2D myRigidBody2D;

    void Start()
    {
        player = FindObjectOfType<Player>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider other)
    {
        if (other.tag == "Player")
        {
            //Player take damage
            Destroy(gameObject);
        }
    }
}