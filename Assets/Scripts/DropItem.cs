using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject dropBag;
    public GameObject prefab;
    public PlayerAI player = new PlayerAI();
	// Use this for initialization
	void Start ()
	{
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyUp(KeyCode.K))
	    {
	        DropBagWithItems();
	    }
	}

    void AddItemToBag(Item item)
    {
        
    }

    void DropBagWithItems()
    {
        Vector3 vector = new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z);
        dropBag = (GameObject)Instantiate(prefab);
    }
}
