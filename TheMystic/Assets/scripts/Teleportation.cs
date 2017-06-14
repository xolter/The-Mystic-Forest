using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Teleportation : MonoBehaviour
{    
    SaveStats savestats;
    public void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            savestats = other.GetComponent<SaveStats>();
            PlayerPrefs.SetInt("load", 0);
            PlayerPrefs.SetInt("save1", 1);
            savestats.Save();
            NetworkManager.singleton.ServerChangeScene("Base");            
        }
    }
}
