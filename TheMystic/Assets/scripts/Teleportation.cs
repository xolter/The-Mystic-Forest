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
           GameObject[] temp = GameObject.FindGameObjectsWithTag("Player");
           foreach(GameObject player in temp)
           {
              player.GetComponent<SaveStats>().Save();
                Debug.Log(player + "Saved");
           }
           
           PlayerPrefs.SetInt("load", 0);
           PlayerPrefs.SetInt("save1", 1);            
            NetworkManager.singleton.ServerChangeScene("ForestDugeon");            
        }
    }
}
