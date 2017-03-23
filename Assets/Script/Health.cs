using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int maxHealth;
    private int currentHealth;
    private int CurrentMaxHealth;
    private int tempHealth;

    private bool tempHealthOn;
    private bool dead;
	// Use this for initialization
	void Start ()
	{
	    currentHealth = maxHealth;
	    tempHealth = maxHealth;
	    CurrentMaxHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    #region BasicMechanics
    void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        CheckDead(); 
    }

    void RecoverHealth(int heal)
    {
        currentHealth = currentHealth + heal;
        CheckMoreThanMaxHealth();
    }

    void RegenHealth()
    {
        currentHealth = currentHealth + currentHealth / 20;
    }
#endregion

    #region temphealths
    void SetTempHealth(int health)
    {
        tempHealth = health;
        CheckMoreThanMaxHealth();
        tempHealthOn = true;
    }

    void ReduceTempHealth(int healthReduce)
    {
        tempHealth = tempHealth - healthReduce;
        CheckMoreThanMaxHealth();
        tempHealthOn = true;
    }

    void IncreaseTempHealth(int healthincrease)
    {
        tempHealth = tempHealth + healthincrease;
        CheckMoreThanMaxHealth();
        tempHealthOn = true;
    }

    void RemoveTempHealth()
    {
        tempHealthOn = false;
    }
    #endregion

    #region Checks
    void CheckMoreThanMaxHealth() 
    {
        if (currentHealth > maxHealth && tempHealthOn == false)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth > tempHealth && tempHealthOn == true)
        {
            currentHealth = tempHealth;
        }
        CheckTempHealth();
    }

    void CheckDead()
    {
        if (currentHealth < 0)
        {
            currentHealth = 0;
            dead = true;
        }
    }

    void CheckTempHealth()
    {
        if (tempHealthOn == true)
        {
            CurrentMaxHealth = tempHealth;
        }
        else
        {
            CurrentMaxHealth = maxHealth;
        }
    }
#endregion

}
