using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopBuyItem : MonoBehaviour, IPointerClickHandler {

    public Camera mainCamera;
    public static int shopItemNumber;
    private int id;

    public ShopBuyItem()
    {
        id = shopItemNumber;
        shopItemNumber++;
    }

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (hit = Physics2D.Raycast(ray.origin, new Vector2(0, 0)))
        {
            Debug.Log(hit.collider.name);
            Debug.Log("I have been clicked");
        }

    }

    public int GetId()
    {
        return id;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("I have been clicked");
        GameObject playerGameObject = GameObject.Find("MeleePlayer");
        Inventory playerInventory = (Inventory)playerGameObject.GetComponent(typeof(Inventory));
        Wallet playerWallet = (Wallet) playerGameObject.GetComponent(typeof(Wallet));
        Debug.Log("Player has been found!");
        Debug.Log("Maak shop aan vanuit ShopBuyItem");
        Shop shop = new Shop();
        if (shop.BuyItem(0).Price > playerWallet.Gold)
        {
            Debug.Log("You can't buy this item!");
            return;
        }
        playerWallet.Gold -= shop.BuyItem(0).Price;
        int itemcount = playerInventory.InventoryItems.Count;
        Debug.Log("De inventory bevat " + itemcount + "items");
        playerInventory.InventoryItems.Add(shop.BuyItem(0));
        Debug.Log("De Inventory bevat " + playerInventory.InventoryItems.Count + "items");
        if (playerInventory.InventoryItems.Count > itemcount)
        {
            Debug.Log("Item is toegevoegd aan Inventory!");
        }
        else
        {
            Debug.Log("Helaas. Het item is niet toegevoegd.");
        }
    }
}
