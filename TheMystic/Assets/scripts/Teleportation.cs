﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Teleportation : MonoBehaviour
{

    //GameObject player;
    //SaveStats savestats;

    void Start()
    {
        //PlayerPrefs.SetInt("save1", 0);
        //PlayerPrefs.SetInt("load", 0);        
        //savestats = player.GetComponent<SaveStats>();

    }
    public void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            //PlayerPrefs.SetInt("save1", 1);
            //savestats.Save();
            NetworkManager.singleton.ServerChangeScene("Base");
            //SceneManager.LoadScene("Base");
        }
    }
}
