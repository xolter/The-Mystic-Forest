using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SyncAnimator : NetworkBehaviour
{
    private NetworkAnimator networkAnimator;


    public override void OnStartLocalPlayer()
    {
        networkAnimator = GetComponent<NetworkAnimator>();
        for (int i = 0; i < networkAnimator.animator.parameterCount; i++)
            networkAnimator.SetParameterAutoSend(i, true);
    }

    public override void PreStartClient()
    {
        networkAnimator = GetComponent<NetworkAnimator>();
        for (int i = 0; i < networkAnimator.animator.parameterCount; i++)
            networkAnimator.SetParameterAutoSend(i, true);
    }
}