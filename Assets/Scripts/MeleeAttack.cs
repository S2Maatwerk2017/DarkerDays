using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public int DamageToGive;
    public GameObject DamageBurst;
    public GameObject DamageNumber;

    public int XP { get; private set; }
    public int Level { get; private set; }
    public int MaxHealth { get; private set; }

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
            col.gameObject.GetComponent<Enemy>().TakeDamage(5);
            Instantiate(DamageBurst, col.gameObject.GetComponent<Transform>().position,
                col.gameObject.GetComponent<Transform>().rotation);
            var clone = (GameObject)Instantiate(DamageNumber, col.gameObject.GetComponent<Transform>().position + new Vector3(0f, 2f, 0.5f),
                Quaternion.Euler(90f, 0f, 0f));
            clone.GetComponent<DamageNumbers>().damageNumber = DamageToGive;
        }
    }
}
