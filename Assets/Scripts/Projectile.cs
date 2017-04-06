using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed = 0;
    private GameObject player;
    public GameObject DamageNumber;
    private Rigidbody myRigidBody;
    public int DamageToGive;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myRigidBody = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other is BoxCollider)
        {
            if (!player.GetComponent<PlayerHealthManager>().iFramesActive)
            {
                player.GetComponent<PlayerHealthManager>().HurtPlayer(DamageToGive);
                var clone = (GameObject)Instantiate(DamageNumber, player.GetComponent<Transform>().position + new Vector3(0f, 2f, 0.5f),
                        Quaternion.Euler(90f, 0f, 0f));
                clone.GetComponent<DamageNumbers>().damageNumber = DamageToGive;
            }
            Destroy(gameObject);
        }
        //if(other.gameObject.tag == "World")
        //{
        //    Destroy(gameObject);
        //}
    }
}