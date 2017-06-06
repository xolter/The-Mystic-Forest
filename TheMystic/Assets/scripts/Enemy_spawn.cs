using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawn : MonoBehaviour
{
    public GameObject enemy;
    public Enemy_Health health;
    //public string tag;
	void Start ()
    {               
        Instantiate(enemy,transform.position, transform.rotation);
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        health = enemy.GetComponent<Enemy_Health>();
        Debug.Log("spawned");
    }
	
	void Update ()
    {
        Debug.Log("cur life [SPAWN]= " + health.current_health);
        //if (health.current_health == 0)
        //{
        //    Debug.Log("DEAD");
        //    Destroy(enemy, 5f);
        //}
    }
}
