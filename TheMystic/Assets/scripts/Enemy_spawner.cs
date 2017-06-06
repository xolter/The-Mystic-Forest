﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawner : MonoBehaviour
{
    public GameObject enemy;
    float coolDown = 15f;
    float currentCoolDown = 0f;
	void Start ()
    {
        InvokeRepeating("Spawn", currentCoolDown, coolDown);               
    }   
    void Spawn()
    {
        if (PlayerStats.currentHealth <= 0f)
            return;
        Instantiate(enemy, transform.position, transform.rotation);                     
    }
}
