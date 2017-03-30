using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionArrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {       
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("YAY");
            Destroy(gameObject);

            col.gameObject.GetComponent<Health>().TakeDamage(5);
            if (col.gameObject.GetComponent<Health>().dead == true)
            {
                Destroy(col.gameObject);
            }

        }
    }

}
