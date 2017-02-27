using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {

	public void LOAD_SCENE()
	{
		Application.LoadLevel ("ScenePrincipale");
	}
	public void QUIT_GAME()
	{
		Application.Quit ();
	}
	public void BACK_TO_MENU()
	{
		Application.LoadLevel ("MainMenu");
	}
	public void TO_OPTION()
	{
		Application.LoadLevel ("OptionMenu");
	}
}
