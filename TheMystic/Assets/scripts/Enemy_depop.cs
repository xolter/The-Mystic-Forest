﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_depop : MonoBehaviour {

    public GameObject self;
    public Enemy_Health health;
	void Update ()
    {
        if (health.current_health <= 0)
            Destroy(self, 5f);	
	}
}
