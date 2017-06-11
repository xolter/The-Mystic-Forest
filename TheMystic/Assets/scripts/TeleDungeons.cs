﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleDungeons : MonoBehaviour {

    GameObject player;
    SaveStats savestats;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        savestats = player.GetComponent<SaveStats>();

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerPrefs.SetInt("load", 0);
            PlayerPrefs.SetInt("save1", 1);
            savestats.Save();
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            SceneManager.LoadScene("ForestDugeon");
        }
    }
}
