using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed = 0;
    public GameObject player;
    private Rigidbody myRigidBody;
    public int Damage;

    void Start()
    {
        player = GameObject.Find("Player");
        myRigidBody = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other is BoxCollider)
        {
            player.GetComponent<Health>().TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}