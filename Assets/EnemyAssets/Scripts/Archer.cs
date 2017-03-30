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
        if (Timer >= 60)
        {
             //TO BE FIXED !!!!!!!!!!!!!!!!!!
            this.transform.LookAt(Player.transform);
            var arrow = Instantiate(projectile,this.transform.position, Quaternion.identity);
            arrow.GetComponent<Rigidbody>().velocity = (Player.transform.position - transform.position).normalized * 2;
                        
            Timer = 0;
        }
        Timer++;
       
        Debug.Log("Archer Attack");
    }
}
