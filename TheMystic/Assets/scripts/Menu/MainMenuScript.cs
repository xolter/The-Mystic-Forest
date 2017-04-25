using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {

	int lastscene = Application.loadedLevel;

	public void LOAD_SCENE()
	{
		Application.LoadLevel ("1");
	}
	public void QUIT_GAME()
	{
		Application.Quit ();
	}
	public void BACK_TO_PREVIOUS()
	{
		Application.LoadLevel (lastscene);
	}
	public void TO_MENU()
	{
		Application.LoadLevel ("MainMenu");
	}
}
