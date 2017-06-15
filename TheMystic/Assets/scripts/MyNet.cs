using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MyNet : NetworkManager
{
    public override void OnClientSceneChanged(NetworkConnection conn)
    {
        base.OnClientSceneChanged(conn);
        PlayerStats.players.Clear();
    }
    public void StartupHost()
    {
        SetPort();
        NetworkManager.singleton.StartHost();
    }

    public void JoinGame()
    {
        //SetIPAddress();
        SetPort();
        NetworkManager.singleton.StartClient();
    }

    void SetIPAddress()
    {
        string ipAddress = GameObject.Find("InputFieldIPAdress").transform.FindChild("Text").GetComponent<GUIText>().text;
        NetworkManager.singleton.networkAddress = ipAddress;
    }

    void SetPort()
    {
        NetworkManager.singleton.networkPort = 7777;
    }

    void OnLevelWasLoaded(int level)
    {
        if (level == 0)
        {
            //SetupMenuSceneButton();          
            StartCoroutine(SetupMenuSceneButton());
        }
        else
            SetupOtherSceneButton();
    }

    IEnumerator SetupMenuSceneButton()
    {
        yield return new WaitForSeconds(0.3f);
        GameObject.Find("Host").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("Host").GetComponent<Button>().onClick.AddListener(StartupHost);
        GameObject.Find("Join").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("Join").GetComponent<Button>().onClick.AddListener(JoinGame);
    }
    void SetupOtherSceneButton()
    {
        GameObject.Find("Disconnect").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("Disconnect").GetComponent<Button>().onClick.AddListener(NetworkManager.singleton.StopHost);
    }
}