using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int playerMaxHealth;
    public int playerCurrentHealth;
    [HideInInspector] public bool iFramesActive;
    public float iFramesLength;
    private float iFrames;
    private SpriteRenderer playerSprite;

    // Use this for initialization
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }

        if (iFramesActive)
        {
            if (iFrames > iFramesLength * .66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, .5f);
            }
            else if (iFrames > iFramesLength * .33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (iFrames > 0f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, .5f);
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                iFramesActive = false;
            }
            iFrames -= Time.deltaTime;
        }
    }

    public void HurtPlayer(int value)
    {
        playerCurrentHealth -= value;

        iFramesActive = true;
        iFrames = iFramesLength;
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    public void HealPlayer(int healing)
    {
        playerCurrentHealth = playerCurrentHealth + healing;
        if (playerCurrentHealth >= playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
        }
    }
}
