using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Assets.Scripts;

public static class Load_ItemList
{
    public static List<Item> ItemsList = new List<Item>();
    public static Item item { get; private set; }



    private static string FilePath = Application.dataPath + "/TekstFood.txt";

    // Use this for initialization

    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }*/

    public static List<Item> Items()
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
                        HP_Item hp = new HP_Item(Convert.ToInt32(words[1]), words[2], Convert.ToInt32(words[3]), words[4], Convert.ToInt32(words[5]), words[6], Convert.ToInt32(words[7]),Convert.ToInt32(words[8]),Convert.ToInt32(words[9]));
                        ItemsList.Add(hp);
                    }
                }
            }
            return ItemsList;
        }
        else
        {
            throw new Exception("geen items");
        }
    }

    public static Item GetItemByID(int ID)
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
