using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipItem : MonoBehaviour
{

    public Button btnEquipItem;
	// Use this for initialization
	void Start () {
		btnEquipItem.onClick.AddListener(()=>equipSelectedItem());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void equipSelectedItem()
    {
        Debug.Log("Equip item click");
    }
}
