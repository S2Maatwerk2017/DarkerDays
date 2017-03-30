using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int damage;

	// Use this for initialization
	void Start ()
    {
        damage = 10;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // On collision
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
}
