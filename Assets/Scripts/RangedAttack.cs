using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour {

    public GameObject projectilePrefab;
    private List<GameObject> Projectiles = new List<GameObject>();
    Rigidbody rigidbody;
    GameObject arrow;
    MovemnetPlayerController movementPlayer;

    private float projectileVelocity;



	// Use this for initialization
	void Start () {
        projectileVelocity = 10f;

    }
	
	// Update is called once per frame
	void Update ()
    {
        movementPlayer = GetComponent<MovemnetPlayerController>();
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



}
