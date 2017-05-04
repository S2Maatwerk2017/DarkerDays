using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	private readonly string saveDataExtension = "GAMESAVE";

	public Canvas PauseMenu;

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

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			PauseGame();
		}
	}

	public void PauseGame()
	{
		if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
			PauseMenu.enabled = false;
		}
		else
		{
			Time.timeScale = 0;
			PauseMenu.enabled = true;
		}
	}

	public void NewGame(string levelname)
	{
		Application.LoadLevel(levelname);
	}

	public void SaveGame(string savename)
	{
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "//" + savename + "." + saveDataExtension);
		binaryFormatter.Serialize(file, World);
		file.Close();
	}

	public void LoadGame(string savename)
	{
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream file = File.Open(Application.persistentDataPath + "//" + savename + saveDataExtension, FileMode.Open);
		World = (World)binaryFormatter.Deserialize(file);
		file.Close();
	}

	public List<string> GetSaveNames()
	{
		var data = Directory.GetFiles(Application.persistentDataPath, "*." + saveDataExtension).ToList();
		List<string> savenames = new List<string>();
		foreach (string s in data)
		{
			savenames.Add(s.Substring((Application.persistentDataPath.Length + 1), s.Length - (Application.persistentDataPath.Length + 1 + saveDataExtension.Length + 1)));
		}
		return savenames;
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
