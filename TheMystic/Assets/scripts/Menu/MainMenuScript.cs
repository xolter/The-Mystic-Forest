using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class MainMenuScript : NetworkBehaviour
{

    public void LOAD_SCENE()
	{
        NetworkManager.singleton.ServerChangeScene("1");
        NetworkManager.singleton.matchSize = 1;
        NetworkManager.singleton.StartHost();
	}
	public void QUIT_GAME()
	{
		Application.Quit ();
	}
}
