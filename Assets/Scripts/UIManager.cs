﻿using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Skills;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Slider ExpBar;
    public Text healthText;
    public Text LvlText;
    public Text EXPText;
    public Text GoldText;
    public Slider apBar;
    public Text APText;
    private PlayerHealthManager playerHealth;
    private PlayerLevel playerLevel;
    public MovemnetPlayerController playerCtrl;
    private ActionPoints actionPoints;
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
        actionPoints = FindObjectOfType<ActionPoints>();
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
        EXPText.text = "EXP: " + playerLevel.XP;
        GoldText.text = Convert.ToString(playerCtrl.ToStringGold());
<<<<<<< HEAD
=======
        apBar.maxValue = actionPoints.MaxActionPoints;
        apBar.value = actionPoints.CurrentActionPoints;
        APText.text = actionPoints.ToString();
>>>>>>> 4fbc87018c66d36f0dcfd191b769fe1a0ad220c7
    }
}
