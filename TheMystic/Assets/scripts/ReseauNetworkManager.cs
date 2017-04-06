using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ReseauNetworkManager : NetworkManager {

	public void START_HOST()
	{
		SetPort ();
		NetworkManager.singleton.StartHost ();
	}
	public void JOIN_GAME()
	{
		SetIPAddress ();
		NetworkManager.singleton.StartClient ();
	}
	void SetIPAddress()
	{
		string ipAddress = GameObject.Find ("InputFieldIPAddress").transform.FindChild ("Text").GetComponent<Text> ().text;
		NetworkManager.singleton.networkAddress = ipAddress;
	}
	void SetPort()
	{
		NetworkManager.singleton.networkPort = 7777;
	}	
}
