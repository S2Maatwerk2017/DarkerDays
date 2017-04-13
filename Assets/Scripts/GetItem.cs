using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{

    private Inventory Inventory = new Inventory();
    private PlayerAI Player = new PlayerAI();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            collision.gameObject.SetActive(false);
            Inventory.ListWithItems.Add(new Item());
        }
    }
}
