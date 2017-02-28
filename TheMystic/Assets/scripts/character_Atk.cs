using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_Atk : MonoBehaviour
{
    public GameObject Target;
	// Use this for initialization
	void Start ()
    {
        float damage = 15;
		float range = 10;               //ca compilait pas a cause de ca mais la range je sais pas a cb faut mettre
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }	
	}

    private void Attack()
    {

    }
}
