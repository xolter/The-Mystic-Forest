﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseurManager : MonoBehaviour {

    public GameObject menuObject;
    public GameObject deathObject;
    public GameObject skillsObject;

    // Update is called once per frame
    void Update ()
    {
        if (menuObject.activeInHierarchy || deathObject.activeInHierarchy || skillsObject.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
	}
}
