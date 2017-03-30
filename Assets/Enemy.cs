using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void ShootProjectileAtPlayer(float enemyX, float enemyY, float enemyZ, Quaternion quaternion)
    {
        // Condition [Strategy]
        GameObject projectile = new GameObject();
        Instantiate(projectile, new Vector3(enemyX, enemyY, enemyZ), quaternion);
    }
}