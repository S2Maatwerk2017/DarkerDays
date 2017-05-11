using UnityEditor;

public class PlayerBundel
{
	public MovemnetPlayerController MovementPlayerController;
	public PlayerLevel PlayerLevel;
	public Wallet Wallet;
	public string IsInLevel;
	
	public PlayerBundel(){}

	public PlayerBundel(MovemnetPlayerController movementPlayerController, PlayerLevel playerLevel, Wallet wallet)
	{
		this.MovementPlayerController = movementPlayerController;
		this.PlayerLevel = playerLevel;
		this.Wallet = wallet;
		this.IsInLevel = EditorApplication.currentScene;
	}
}