using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotEnoughMoneyMessageboxScript : MonoBehaviour
{
    public GameObject Textbox;
    public bool isVisible = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIsVissable(bool value)
    {
        isVisible = value;
        Textbox.SetActive(isVisible);
    }
}
