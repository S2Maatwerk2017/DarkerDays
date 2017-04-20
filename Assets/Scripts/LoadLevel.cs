using UnityEngine;

public class LoadLevel : MonoBehaviour
{
	public void loadLevel(string scenename)
	{
		Application.LoadLevel(scenename);
	}

	public void reloadCurrentLevel()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}
