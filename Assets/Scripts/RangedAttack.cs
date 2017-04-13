using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour {

    public GameObject projectilePrefab;
    private List<GameObject> Projectiles = new List<GameObject>();
    //private Vector3 mousePosition;
    //private float aimAngel;
    //private Vector3 crossProduct;
    Rigidbody rigidbody;
    GameObject arrow;
    private float attackTimeCounter;
    //Camera cam;
    MovemnetPlayerController movementPlayer;

    private float projectileVelocity;



	// Use this for initialization
	void Start () {
        projectileVelocity = 10f;
        //cam = GameObject.Find("TestCamera").GetComponent<Camera>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        movementPlayer = GetComponent<MovemnetPlayerController>();
        //cam = GameObject.Find("TestCamera").GetComponent<Camera>();
        //mousePosition = cam.ScreenToWorldPoint(Input.mousePosition).normalized;

        //aimAngel = Vector2.Angle(Vector2.up, mousePosition);
        //crossProduct = Vector3.Cross(Vector2.up, mousePosition);

        //if (crossProduct.z < 0)
        //    aimAngel = 360 - aimAngel;

        if (Input.GetButtonDown("Fire1"))
        {
            if (movementPlayer.playerRangedAttacking == false)
            {
                attackTimeCounter = movementPlayer.attackTime;
                movementPlayer.playerRangedAttacking = true;
                arrow = (GameObject)Instantiate(projectilePrefab, transform.position, Quaternion.Euler(90f, 0f, 0f));
                Projectiles.Add(arrow);
                rigidbody = arrow.GetComponent<Rigidbody>();
                Vector3 arrowDirection = new Vector3(movementPlayer.lastMove.x, 0f, movementPlayer.lastMove.z);
                rigidbody.AddForce(arrowDirection * projectileVelocity, ForceMode.Impulse);

                Destroy(arrow, 3.0f);
            }



        }

        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter < 0)
        {
            movementPlayer.playerRangedAttacking = false;
            movementPlayer.ani.SetBool("PlayerRangedAttacking", false);
        }
        PlayerRangedAttackCheck();

        
	}

    private void PlayerRangedAttackCheck()
    {
        movementPlayer.ani.SetBool("PlayerRangedAttacking", movementPlayer.playerRangedAttacking);
        
    }

// j.hoefnagel@fontys.nl

}
