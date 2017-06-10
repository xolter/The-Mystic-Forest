using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSaves : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        PlayerPrefs.SetInt("load", 0);
        PlayerPrefs.SetInt("save1", 0);
    }
    public void loadGame()
    {
       
        if (PlayerPrefs.HasKey("x"))
        {
            PlayerPrefs.SetInt("load", 1);
            SceneManager.LoadScene(PlayerPrefs.GetString("scene"));
        }
    }
}
