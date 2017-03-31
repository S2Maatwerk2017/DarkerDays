﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public int DamageToGive;
    public GameObject DamageBurst;

	// Use this for initialization
	void Start()
    {
		
	}
	
	// Update is called once per frame
	void Update()
    {

	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("YAYmelee");

            col.gameObject.GetComponent<Health>().TakeDamage(5);
            if (col.gameObject.GetComponent<Health>().dead == true)
            {
                Destroy(col.gameObject);
            }

        }
    }
}