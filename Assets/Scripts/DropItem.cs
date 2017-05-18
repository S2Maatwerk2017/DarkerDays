using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropItem : MonoBehaviour
{

    public Button btnDropItem;
    private Inventory inventory = new Inventory();
    private MovemnetPlayerController player = new MovemnetPlayerController();
	// Use this for initialization
	void Start ()
	{
		btnDropItem.onClick.AddListener(()=> DropSelectedItem());

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DropSelectedItem()
    {
        Item selectedItem = new HP_Item(1, "Banaan", 2, "Fruit", 1, "Banana", 5); //Methode schrijven die bijhoudt welke item er is geselecteerd
        foreach (Item I in inventory.InventoryItems)
        {
            if (I.Name == selectedItem.Name)
            {
                if (I.GetType() == typeof(HP_Item))
                {
                    GameObject droppedItem = (GameObject) Instantiate(I,player.transform.position,Quaternion.identity)
                }
            }
        }
    }
}
