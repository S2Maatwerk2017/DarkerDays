using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Enemy, IStrategy {

    private float Timer = 0;
    public GameObject projectile;
	
    public override void DoBehavior()
    {
        base.RunFromPlayer();
    }

    public override void Attack()
    {
        /*
        this.transform.LookAt(Player.transform);
        Instantiate(projectile, this.transform);
        projectile.GetComponent<Rigidbody>().position += Vector3.forward * Time.deltaTime * projectile.GetComponent<Projectile>().speed;
       */
        Debug.Log("Archer Attack");
    }
}
