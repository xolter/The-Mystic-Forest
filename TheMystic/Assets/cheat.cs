using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheat : MonoBehaviour
{
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.M))
            PlayerStats.localPlayer.Lvl = 10;
	}
}
