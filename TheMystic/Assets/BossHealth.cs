using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    [SerializeField]
    GameObject bossHealth;
    private bool once = true;
	void Update ()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "Base")
        {
            if (once)
            {
                bossHealth.SetActive(true);
                once = false;
            }
        }
        else
            bossHealth.SetActive(false);
	}
}
