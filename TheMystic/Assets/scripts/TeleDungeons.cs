using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleDungeons : MonoBehaviour {

    /*GameObject player;
    SaveStats savestats;*/

    void Start()
    {
        /*player = GameObject.FindGameObjectWithTag("Player");
        savestats = player.GetComponent<SaveStats>();*/

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //savestats.Save();
            //PlayerPrefs.SetInt("load", 2);
            SceneManager.LoadScene("ForestDugeon");
        }
    }
}
