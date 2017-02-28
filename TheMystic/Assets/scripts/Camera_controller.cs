﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour {

    public Transform target;
    public float lookSmooth = 0.09f;
    public Vector3 offsetFromTarget = new Vector3(0, 6, -8);
    public float xTilt = 10;

    Vector3 destination = Vector3.zero;
    CharacterController charController;
    float rotateVel = 0;

    void Start()
    {
        SetCamertaTarget(target);
    }
    void SetCamertaTarget(Transform t)
    {
        target = t;
        if (target != null)
        {
            if (target.GetComponent<CharacterController>())
            {
                charController = target.GetComponent<CharacterController>();
            }
            else
            {
                Debug.LogError("The camera's target must be a character controller!");
            }
        }
        else
        {
            Debug.LogError("Your camera need target");
        }
    }

    void LateUpdate()
    {
        //moving
        MoveToTarget();
        //rotating
        LookAtTarget();
    }

    void MoveToTarget()
    {
        destination = charController.TargetRotation * offsetFromTarget;
        destination += target.position;
        transform.position = destination;
    }

    void LookAtTarget()
    {
        float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref rotateVel, lookSmooth);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, eulerYAngle, 0);
    }
}
