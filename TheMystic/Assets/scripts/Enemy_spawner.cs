using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawner : MonoBehaviour
{
    public GameObject enemy;
    public float coolDown = 15f;
    public float currentCoolDown = 0f;
    PlayerStats playerstats;
    void Start ()
    {
        playerstats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        InvokeRepeating("Spawn", currentCoolDown, coolDown);               
    }   
    void Spawn()
    {
        if (playerstats.currentHealth <= 0f)
            return;
        Instantiate(enemy, transform.position, transform.rotation);                     
    }
}
