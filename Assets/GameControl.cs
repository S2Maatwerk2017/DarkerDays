using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameControl : MonoBehaviour {

	public static GameControl Control;
	public World World;

	void Awake()
	{
		if (Control == null)
		{
			DontDestroyOnLoad(gameObject);
			Control = this;
		}
		else if (Control != this)
		{
			Destroy(gameObject);
		}
	}

	void SaveGame()
	{
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/saveData.GAMESAVE");
		binaryFormatter.Serialize(file, World);
		file.Close();
	}

	void LoadGame()
	{
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream file = File.Open(Application.persistentDataPath + "/saveData.GAMESAVE", FileMode.Open);
		World = (World)binaryFormatter.Deserialize(file);
		file.Close();
	}
}

//het onderstaande is tijdelijk

[Serializable]
public class World
{
	public Player Player;
	public List<Enemy> Enemies;
}

[Serializable]
public abstract class Character
{
	public int Health;	
}

[Serializable]
public class Player : Character
{
	public int ActionPoints;
}

[Serializable]
public class Enemy : Character
{

}
