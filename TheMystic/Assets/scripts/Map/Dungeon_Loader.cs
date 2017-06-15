using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Dungeon_Loader : NetworkBehaviour
{
    SaveStats savestats;
    GameObject generator;
    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in temp)
            {
                player.GetComponent<SaveStats>().Save();
                Debug.Log(player + "Saved");
            }
            PlayerPrefs.SetInt("load", 0);
            PlayerPrefs.SetInt("save1", 1);
            bool res = false;
            foreach (PlayerStats player in PlayerStats.players)
                res = res || player.Lvl >= 10;
            if (!res)
                NetworkManager.singleton.ServerChangeScene("ForestDugeon");
            else
                NetworkManager.singleton.ServerChangeScene("Base");
        }
    }
}