using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Assets.Scripts;

public class Player_Inventory : MonoBehaviour
{
    public List<Item> ItemsList = new List<Item>();
    public Item item { get; private set; }
<<<<<<< HEAD:Assets/Scripts/InventoryMap/Player_Inventory.cs
    private string FilePath = @"D:\Unity Projects\ProftaakS21M\DarkerDays\Assets\TekstFood.txt";
=======
    private string FilePath = @"C:\Users\Sjors\Desktop\School\Semester 2 Maatwerk\DarkerDays\Assets\TekstFood.txt";
>>>>>>> 4fbc87018c66d36f0dcfd191b769fe1a0ad220c7:Assets/Scripts/Inventory/Player_Inventory.cs

    // Use this for initialization

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<Item> Items()
    {
        ItemsList.Clear();
        if (File.Exists(FilePath))
        {
            using (StreamReader sr = new StreamReader(FilePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] words = line.Split(';');

                    if (words[0] == "HPItem")
                    {
                        HP_Item hp = new HP_Item(Convert.ToInt32(words[1]), words[2], Convert.ToInt32(words[3]), words[4], Convert.ToInt32(words[5]), words[6], Convert.ToInt32(words[7]));
                        ItemsList.Add(hp);
                    }
                }
            }
            return ItemsList;
        }
        else
        {
            throw new Exception("geen items");
            return null;
        }
    }

    public Item GetItemByID(int ID)
    {
        for (int i = 0; i < Items().Count; i++)
        {
            if (Items()[i].ItemID == ID)
            {
                return Items()[i];
            }
        }
        return null;
    }

}
