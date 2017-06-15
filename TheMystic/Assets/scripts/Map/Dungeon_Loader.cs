using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Dungeon_Loader : NetworkBehaviour
{
    SaveStats savestats;
    GameObject generator;
    private void Update()
    {
        bool res = false;
        foreach (PlayerStats stats in PlayerStats.players)
            res = res || (stats.Lvl >= 10);
        Debug.Log("res:"+res);
    }
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
            NetworkManager.singleton.ServerChangeScene("Base");
            
           {
               var k = (GameObject)Instantiate(generator, new Vector3(Map_Generator2.xpos,0,0), new Quaternion());
               NetworkServer.Spawn(k);
           }
        }
    }
}
