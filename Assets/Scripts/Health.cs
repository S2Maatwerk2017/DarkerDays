using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
    private int CurrentMaxHealth;
    private int tempHealth;

    private bool tempHealthOn;
    public bool dead { get; private set; }
	// Use this for initialization
	void Start ()
	{
	    currentHealth = maxHealth;
	    tempHealth = maxHealth;
	    CurrentMaxHealth = maxHealth;
        dead = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    #region BasicMechanics
    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        CheckDead(); 
    }

    public void RecoverHealth(int heal)
    {
        currentHealth = currentHealth + heal;
        CheckMoreThanMaxHealth();
    }

    public void RegenHealth()
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
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            dead = true;
        }
        else
        {
            dead = false;
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
