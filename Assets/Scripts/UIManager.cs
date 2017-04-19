using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text healthText;
    public Text LvlText;
    private PlayerHealthManager playerHealth;
    private PlayerLevel playerLevel;
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
    }
}
