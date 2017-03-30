using System.Collections;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //other.gameObject.GetComponent<EnemyHealth>().TakeDamage(DamageToGive);
            Instantiate(DamageBurst, transform.position, transform.rotation);
        }
    }
}
