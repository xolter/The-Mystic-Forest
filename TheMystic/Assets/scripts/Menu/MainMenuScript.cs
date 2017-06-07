using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    public void LOAD_SCENE()
	{
        SceneManager.LoadScene("1");
	}
	public void QUIT_GAME()
	{
		Application.Quit ();
	}
	public void TO_MENU()
	{
        SceneManager.LoadScene("MainMenu");
	}
    public void TO_RANDOM()
    {
        SceneManager.LoadScene("ForestDugeon");
    }
   
}
