using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionArrow : MonoBehaviour
{

    public int DamageToGive;
    public GameObject DamageBurst;
    public GameObject DamageNumber;
    private GameObject Player;

    // Use this for initialization
<<<<<<< HEAD
    void Start()
    {
        Player = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

    }

=======
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
>>>>>>> 4fbc87018c66d36f0dcfd191b769fe1a0ad220c7
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {           

            Instantiate(DamageBurst, col.gameObject.GetComponent<Transform>().position,
                col.gameObject.GetComponent<Transform>().rotation);
            var clone = (GameObject)Instantiate(DamageNumber, col.gameObject.GetComponent<Transform>().position + new Vector3(0f, 2f, 0.5f),
                Quaternion.Euler(90f, 0f, 0f));
            clone.GetComponent<DamageNumbers>().damageNumber = DamageToGive;

            if (col.gameObject.GetComponent<Enemy>().TakeDamage(DamageToGive) == true)
            {
                Player.GetComponent<MovemnetPlayerController>().IncreaseXP(col.gameObject.GetComponent<Enemy>().GetXP());
                Player.GetComponent<MovemnetPlayerController>().IncreaseGold(col.gameObject.GetComponent<Enemy>().GetGold());
            }

        }

        if (col.gameObject.tag != "Player")
        {
            Destroy(gameObject);

        }
    }
}
