using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Enemy_spawner : NetworkBehaviour
{
    public GameObject enemy;
    public float coolDown = 15f;
    public float currentCoolDown = 0f;
    GameObject[] players;
    [SerializeField]
    Transform position;
    void Start ()
    {
        //players = null; //GameObject.FindGameObjectsWithTag("Player");
        InvokeRepeating("Spawn", currentCoolDown, coolDown);               
    }   
    void Spawn()
    {        
        
        if (!isServer)
            return;
        if (PlayerStats.players.Find(p => p.currentHealth > 0f) == null)
            return;
        var toSpawn = (GameObject)Instantiate(enemy, position.position, position.rotation);
        NetworkServer.Spawn(toSpawn);
    }
}
