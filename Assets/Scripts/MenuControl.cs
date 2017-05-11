using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
	public GameControl control;

	private Canvas previousMenu;

	private bool isMenuOpen
	{
		get
		{
			return MainMenu.enabled || ChooseCharacterMenu.enabled || SaveMenu.enabled || LoadMenu.enabled || YouDiedScreen.enabled;
		}
	}

	public Canvas MainMenu;
	public Canvas ChooseCharacterMenu;
	public Canvas PauseMenu;
	public Canvas SaveMenu;
	public Text SaveGameText;
	public Canvas LoadMenu;
	public Dropdown LoadGamesList;
	public Button LoadGameButton;
	public Canvas YouDiedScreen;

	// Use this for initialization
	void Start()
	{
		MainMenu = MainMenu.GetComponent<Canvas>();
		ChooseCharacterMenu = ChooseCharacterMenu.GetComponent<Canvas>();
		PauseMenu = PauseMenu.GetComponent<Canvas>();
		SaveMenu = SaveMenu.GetComponent<Canvas>();
		LoadMenu = LoadMenu.GetComponent<Canvas>();
		YouDiedScreen = YouDiedScreen.GetComponent<Canvas>();
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
		if (Time.timeScale != 0)
		{
			Time.timeScale = 0;
			PauseMenu.enabled = !isMenuOpen;
		}
		else
		{
			Time.timeScale = 1;
			PauseMenu.enabled = false;
		}
	}

	public void NewGame(string playertype)
	{
		ChooseCharacterMenu.enabled = false;
		control.NewGame(playertype);
	}

	public void ShowLoadMenu(Canvas CurrentMenu)
	{
		foreach (var save in control.GetSaveNames())
		{
			LoadGamesList.options.Add(new Dropdown.OptionData(save));
		}
		if (LoadGamesList.options.Count == 0)
			LoadGameButton.enabled = false;
		else
			LoadGameButton.enabled = true;
		LoadGamesList.RefreshShownValue();
		CurrentMenu.enabled = false;
		LoadMenu.enabled = true;
		previousMenu = CurrentMenu;
	}

	public void LoadGame()
	{
		string text = LoadGamesList.itemText.text;
		if (text != null)
			control.LoadGame(text);
	}

	public void HideLoadMenu()
	{
		LoadMenu.enabled = false;
		previousMenu.enabled = true;
		previousMenu = null;
	}

	public void ShowSaveMenu()
	{
		PauseMenu.enabled = false;
		SaveMenu.enabled = true;
	}

	public void SaveGame()
	{
		control.SaveGame(SaveGameText.text);
		HideSaveMenu();
	}

	public void HideSaveMenu()
	{
		SaveMenu.enabled = false;
		PauseMenu.enabled = true;
	}

	public void HidePauseMenu()
	{
		PauseGame();
	}

	public void ShowCharacterCreation()
	{
		ChooseCharacterMenu.enabled = true;
		MainMenu.enabled = false;
	}

	public void ShowMainMenu()
	{
		MainMenu.enabled = true;
		PauseMenu.enabled = false;
		ChooseCharacterMenu.enabled = false;
		YouDiedScreen.enabled = false;
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
