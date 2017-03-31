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
        movementPlayer.playerRangedAttacking = false;

        if (Input.GetButtonDown("Fire1"))
        {
            
            movementPlayer.playerRangedAttacking = true;
            arrow = (GameObject)Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Projectiles.Add(arrow);           
            rigidbody = arrow.GetComponent<Rigidbody>();
            Vector3 arrowDirection = new Vector3(movementPlayer.lastMove.x, movementPlayer.lastMove.y);
            rigidbody.AddForce(arrowDirection * projectileVelocity, ForceMode.Impulse);

            Destroy(arrow, 3.0f);



        }
        PlayerRangedAttackCheck();

        
	}

    private void PlayerRangedAttackCheck()
    {
        movementPlayer.ani.SetBool("PlayerRangedAttacking", movementPlayer.playerRangedAttacking);
        
    }

// j.hoefnagel@fontys.nl

}
