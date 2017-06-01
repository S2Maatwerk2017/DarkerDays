using UnityEditor;
using UnityEngine;

public class PlayerBundel
{
	public PlayerMovementSave MovementPlayerController;
	public PlayerLevelSave PlayerLevel;
	public WalletSave Wallet;
	public string IsInLevel;
	
	public PlayerBundel() { }

	public PlayerBundel(MovemnetPlayerController movementPlayerController, PlayerLevel playerLevel, Wallet wallet)
	{
		this.MovementPlayerController = new PlayerMovementSave(movementPlayerController);
		this.PlayerLevel = new PlayerLevelSave(playerLevel);
		this.Wallet = new WalletSave(wallet);
		this.IsInLevel = EditorApplication.currentScene;
	}
}

//savable classes, hier zijn ze ten minste nog te vinden in tegenstelling tot de hierarchie.

public class WalletSave
{
	public int Gold { get; private set; }

	public WalletSave(Wallet wallet)
	{
		this.Gold = wallet.Gold;
	}
}

public class PlayerLevelSave
{
	public int Experience { get; private set; }
	public int Level { get; private set; }

	public PlayerLevelSave(PlayerLevel playerLevel)
	{
		this.Experience = playerLevel.XP;
		this.Level = playerLevel.Lvl;
	}
}

public class PlayerMovementSave
{
	public bool isPlayerRanged { get; private set; }
	public Vector3 playerLocation { get; private set; }

	public PlayerMovementSave(MovemnetPlayerController movementPlayerController)
	{
		this.isPlayerRanged = movementPlayerController.isPlayerRanged;
		this.playerLocation = movementPlayerController.gameObject.transform.position;
		
	}
}
