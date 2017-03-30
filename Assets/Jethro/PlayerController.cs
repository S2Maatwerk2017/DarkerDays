using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed;
    public int hitpoints;
    private int currentHitpoints;

	// Use this for initialization
	void Start ()
	{
	    hitpoints = 10;
	    movementSpeed = 5;
	    currentHitpoints = hitpoints;
	}
	
	// Update is called once per frame
	void Update ()
    {
        PlayerWalking();

        if (currentHitpoints <= 0)
        {
            Destroy(gameObject);
        }
	}

    private void PlayerWalking()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime, 0f));
        }
        if (Input.GetAxisRaw("Vertical") < -0.5f || Input.GetAxisRaw("Vertical") > 0.5f)
        {
            transform.Translate(new Vector2(0f,Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime));
        }
    }

    public void TakeDamage(int damage)
    {
        currentHitpoints -= damage;
    }
}
