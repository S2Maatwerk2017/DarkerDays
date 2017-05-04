using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
	public void loadLevel(string scenename)
	{
		SceneManager.LoadScene(scenename);
	}

	public void reloadCurrentLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
