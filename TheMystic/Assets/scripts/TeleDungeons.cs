using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleDungeons : MonoBehaviour {

    SaveStats savestats;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            savestats = other.GetComponent<SaveStats>();
            PlayerPrefs.SetInt("load", 0);
            PlayerPrefs.SetInt("save1", 1);
            savestats.Save();
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            SceneManager.LoadScene("ForestDugeon");
        }
    }
}
