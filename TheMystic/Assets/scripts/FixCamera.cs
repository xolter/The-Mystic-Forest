using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FixCamera : NetworkBehaviour
{
    public Camera camera;
    void Start()
    {
        if (!isLocalPlayer)
        {
            camera.enabled = false;
        }
    }
    void Update()
    {
        if (!isLocalPlayer)
        {
            camera.enabled = false;
        }
    }

}
