using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	private readonly string saveDataExtension = "GAMESAVE";

	public Canvas PauseMenu;

	public static GameControl Control;

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

	public void LoadLevel(string levelname)
	{
		Application.LoadLevel(levelname);
	}

	public void SaveGame(string savename)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(PlayerBundel));
		using (FileStream file = File.Create(Application.persistentDataPath + "//" + savename + "." + saveDataExtension))
		{
			serializer.Serialize(file, getPlayerBundel());
		}
	}

	private PlayerBundel getPlayerBundel()
	{
		var player = GameObject.FindGameObjectWithTag("Player");
		return new PlayerBundel(player.GetComponent<MovemnetPlayerController>(), player.GetComponent<PlayerLevel>(), player.GetComponent<Wallet>());
	}

	public void LoadGame(string savename)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(PlayerBundel));
		using (FileStream file = File.Open(Application.persistentDataPath + "//" + savename + "." + saveDataExtension, FileMode.Open))
		{
			ApplyLoadedPlayer(serializer.Deserialize(file) as PlayerBundel);
		}
	}

	private void ApplyLoadedPlayer(PlayerBundel playerBundel)
	{
		var player = GameObject.FindGameObjectWithTag("Player");
		/*
		player.GetComponent<MovemnetPlayerController>().LoadMovementPlayerController(playerBundel.MovementPlayerController);
		player.GetComponent<PlayerLevel>().LoadPlayerLevel(playerBundel.PlayerLevel);
		player.GetComponent<Wallet>().LoadWallet(playerBundel.Wallet);
		*/
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
