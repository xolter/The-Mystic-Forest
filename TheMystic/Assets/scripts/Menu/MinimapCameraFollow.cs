﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraFollow : MonoBehaviour {

    public Transform target;

    void LateUpdate()
    {
        transform.position = target.position;
    }
}
