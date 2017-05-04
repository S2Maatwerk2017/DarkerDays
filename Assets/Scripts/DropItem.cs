using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropItem : MonoBehaviour
{
    public Button btnDropItem;


    void Start()
    {
        btnDropItem.onClick.AddListener(()=>DropSelectedItem());
    }
    public void DropSelectedItem()
    {
        Debug.Log("Er is geklikt!");
    }
}
