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
            transform.FindChild("UI 2.0").gameObject.SetActive(false);
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
