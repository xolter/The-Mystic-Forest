using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Enemy_spawn : NetworkBehaviour
{
    [SerializeField]
    GameObject toSpawn;
    [SerializeField]
    float delay;
    [SerializeField]
    private float actuaDelay;
    [SerializeField]
    bool once;
    void Update()
    {
        if (!isServer)
            return;
        if (actuaDelay > delay)
        {
            if (once)
            {
                once = false;
                var temp = (GameObject)Instantiate(toSpawn, transform.position, transform.rotation);
                NetworkServer.Spawn(temp);                
            }
        }
        else
        {
            actuaDelay += Time.deltaTime;
        }
    }


}
