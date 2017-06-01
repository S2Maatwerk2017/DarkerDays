using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopBuyItem : MonoBehaviour, IPointerClickHandler {

    public Camera mainCamera;
    public static int shopItemNumber = 0;
    public int id;
    public Item Item;
    public GameObject Player;


    // Use this for initialization
    void Start ()
    {
        //Koppel Itemslot aan juiste item
        Shop shop = new Shop(Load_ItemList.Items());
        Item = shop.Items.ElementAt(shopItemNumber);
        id = Item.ItemID;
        Debug.Log("Tradenummer " + shopItemNumber + " is aangemaakt met een " + Item.Name + " met id " + id + "in de shop.");
        shopItemNumber++;
        Player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (hit = Physics2D.Raycast(ray.origin, new Vector2(0, 0)))
        {
            Debug.Log(hit.collider.name);
            if (id != 0)
            {
                Debug.Log("I have been clicked correct");
            }
            else
            {
                Debug.Log("I have been clicked");
            }
            
        }
        
    }

    public int GetId()
    {
        return id;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(Item.Name + " met id" + id +"wordt gekocht. Dat is de " + shopItemNumber + "e trade.");
        //Zoek de player inventory
        GameObject playerGameObject = GameObject.Find("MeleePlayer");
        //zoek de player zijn wallet
        Wallet playerWallet = (Wallet) playerGameObject.GetComponent(typeof(Wallet));

        //Controleer of speler genoeg gold heeft
        if (Item.Price > playerWallet.Gold)
        {

            Debug.Log("You can't buy this item!");
            return;
        }
        Debug.Log("You lost " + Item.Price + " gold");
        //Betaal item
        playerWallet.Gold -= Item.Price;
        //Verkrijg item in inventory
        Player.GetComponent<Inventory>().AddNewItem(id);

    }
}
