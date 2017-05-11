using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Slider ExpBar;
    public Text healthText;
    public Text LvlText;
    public Text GoldText;
    private PlayerHealthManager playerHealth;
    private PlayerLevel playerLevel;
    public MovemnetPlayerController playerCtrl;
    private static bool UImanagerExists;

    // Use this for initialization
    void Start()
    {
        if (!UImanagerExists)
        {
            UImanagerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        //playerCtrl = FindObjectOfType<MovemnetPlayerController>();
        playerHealth = FindObjectOfType<PlayerHealthManager>();
        playerLevel = FindObjectOfType<PlayerLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;
        ExpBar.maxValue = 100;
        ExpBar.value = playerLevel.XP;
        healthText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
        LvlText.text = "LVL: " + playerLevel.Lvl;
        GoldText.text = Convert.ToString(playerCtrl.ToStringGold());
    }
}
