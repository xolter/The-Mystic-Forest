using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnUlt : NetworkBehaviour
{
    [SerializeField]
    Transform spawn1;
    [SerializeField]
    Transform spawn2;
    [SerializeField]
    Transform spawn3;
    [SerializeField]
    Transform spawn4;
    [SerializeField]
    GameObject toSpawn;   
    // Use this for initialization
    public override void OnStartServer()
    {
        base.OnStartServer();
        var temp1 = (GameObject)Instantiate(toSpawn, spawn1.position, spawn1.rotation);
        var temp2 = (GameObject)Instantiate(toSpawn, spawn2.position, spawn2.rotation);
        var temp3 = (GameObject)Instantiate(toSpawn, spawn3.position, spawn3.rotation);
        var temp4 = (GameObject)Instantiate(toSpawn, spawn4.position, spawn4.rotation);
        NetworkServer.Spawn(temp1);
        NetworkServer.Spawn(temp2);
        NetworkServer.Spawn(temp3);
        NetworkServer.Spawn(temp4);
    }
}
