using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class EquipItem : MonoBehaviour
{

    public Button btnEquipItem;
    private Inventory inventory = new Inventory();
    private PlayerHealthManager player = new PlayerHealthManager();
    // Use this for initialization
    void Start()
    {
        btnEquipItem.onClick.AddListener(() => EquipSelectedItem());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EquipSelectedItem()
    {
        Item selectedItem = new HP_Item(1, "Banaan", 2, "Fruit", 1, "Banana", 5); //Methode schrijven die bijhoudt welke item er is geselecteerd
        foreach (Item I in inventory.InventoryItems)
        {
            if (I.Name == selectedItem.Name)
            {
                if (I.GetType() == typeof(HP_Item))
                {
                    HP_Item hpItem = (HP_Item) I;
                    player.playerCurrentHealth = player.playerCurrentHealth + hpItem.HPGain;
                }
            }
        }
    }
}
