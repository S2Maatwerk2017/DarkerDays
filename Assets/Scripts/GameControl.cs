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

	public GameObject MeleePlayerPrefab;
	public GameObject RangedPlayerPrefab;
	public GameObject CameraPrefab;

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

	public void NewGame(string playertype)
	{
		var defaultMenuCam = FindObjectsOfType<GameObject>().Where(o => o.name == "Camera").FirstOrDefault();

		if (defaultMenuCam != null)
			Destroy(defaultMenuCam);

		var player = playertype == "Melee" ? Instantiate(MeleePlayerPrefab) : Instantiate(RangedPlayerPrefab);
		DontDestroyOnLoad(player);
		CameraPrefab.GetComponent<Camera_Controller>().followTarget = player;
		var camera = Instantiate(CameraPrefab);
		DontDestroyOnLoad(camera);
		LoadLevel("tutorial");
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

	private void destroyPlayerAndCamera()
	{
		var cam = GameObject.FindGameObjectWithTag("MainCamera");
		if (cam != null)
			Destroy(cam);

		var player = GameObject.FindGameObjectWithTag("Player");
		if (player != null)
			Destroy(player);
	}

	private void ApplyLoadedPlayer(PlayerBundel playerBundel)
	{
		destroyPlayerAndCamera();

		var player = isPlayerRanged(playerBundel.MovementPlayerController) ? RangedPlayerPrefab : MeleePlayerPrefab;
		CameraPrefab.GetComponent<Camera_Controller>().followTarget = player;
		player = Instantiate(player);
		var camera = Instantiate(CameraPrefab);

		//player.GetComponent<MovemnetPlayerController>().LoadMovementPlayerController(playerBundel.MovementPlayerController);
		//player.GetComponent<PlayerLevel>().LoadPlayerLevel(playerBundel.PlayerLevel);
		//player.GetComponent<Wallet>().LoadWallet(playerBundel.Wallet);

		DontDestroyOnLoad(player);
		DontDestroyOnLoad(camera);

		LoadLevel(playerBundel.IsInLevel);
	}

	private bool isPlayerRanged(PlayerMovementSave playerMovement)
	{
		return playerMovement.isPlayerRanged;
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

/* premade vorm van methodes binnen de individuele classes die opgeslagen moeten worden

	 * PlayerMovementController
	public void LoadMovementPlayerController(PlayerMovementSave playerMovementSave)
	{
		this.isPlayerRanged = playerMovementSave.isPlayerRanged;
		this.gameObject.transform.position = PlayerMovementSave.playerLocation;
	}

	 * PlayerLevel
	public void LoadPlayerLevel(PlayerLevelSave playerLevel)
	{
		this.XP = playerLevel.Experience;
		this.Lvl = playerLevel.Level;
	}

	 * Wallet
	public void LoadWallet(WalletSave wallet)
	{
		this.Gold = wallet.Gold;
	}
*/
