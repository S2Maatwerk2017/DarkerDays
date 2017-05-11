﻿using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Skills;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text healthText;
    public Text LvlText;
    public Text GoldText;
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
        playerCtrl = FindObjectOfType<MovemnetPlayerController>();
        playerHealth = FindObjectOfType<PlayerHealthManager>();
        playerLevel = FindObjectOfType<PlayerLevel>();
        actionPoints = FindObjectOfType<ActionPoints>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;
        healthText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
        LvlText.text = "LVL: " + playerLevel.Lvl;
        GoldText.text = Convert.ToString(playerCtrl.ToStringGold());
        APText.text = actionPoints.ToString();
    }
}
