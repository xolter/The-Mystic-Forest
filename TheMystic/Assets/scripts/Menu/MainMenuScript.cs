using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class MainMenuScript : NetworkBehaviour
{
    public void LOAD_SCENE()
	{
        NetworkManager.singleton.onlineScene = "1";
        NetworkManager.singleton.onlineScene = "MainMenu";
        NetworkManager.singleton.maxConnections = 1;
        NetworkManager.singleton.ServerChangeScene("1");
        NetworkManager.singleton.StartHost();
	}
    public void HOST()
    {
        Debug.Log("HERE");
        NetworkManager.singleton.ServerChangeScene("1");
        NetworkManager.singleton.maxConnections = 8;
        NetworkManager.singleton.SetMatchHost("Local", 7777, false);
        NetworkManager.singleton.StartHost();
    }
    public void JOIN()
    {
        NetworkManager.singleton.StartClient();       
    }
	public void QUIT_GAME()
	{
		Application.Quit ();
	}
}
