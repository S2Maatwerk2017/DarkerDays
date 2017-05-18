using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text healthText;
    public Text LvlText;
    public Text GoldText;
    public Text NameText;
    public Text DescriptionText;
    public Text HealText;
    private PlayerHealthManager playerHealth;
    private PlayerLevel playerLevel;
    public MovemnetPlayerController playerCtrl;
    private static bool UImanagerExists;

    private MyItem CurrentlySelectedItem;

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
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;
        healthText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
        LvlText.text = "LVL: " + playerLevel.Lvl;
        GoldText.text = Convert.ToString(playerCtrl.ToStringGold());
        if (CurrentlySelectedItem != null)
        {
            string[] Data = CurrentlySelectedItem.GetData();
            NameText.text = Data[0];
            DescriptionText.text = Data[1];
            HealText.text = "Heals for: " + Data[2];
        }
        else
        {
            NameText.text = "";
            DescriptionText.text = "";
            HealText.text = "";
        }
    }

    public void SetCurrentChosenSlot(MyItem myItem)
    {
        CurrentlySelectedItem = myItem;
    }
}
