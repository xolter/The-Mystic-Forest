using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int max_health = 100;
    public int current_health = 100;
    public float healthBar_length;
    // Use this for initialization
    void Start()
    {
        healthBar_length = Screen.width / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Update_currentHealth(0);
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, healthBar_length, 20), current_health + "/" + max_health);
    }

    public void Update_currentHealth(int n)
    {
        current_health += n;
        if (current_health < 0)
        {
            current_health = 0;
        }
        if (current_health > max_health)
        {
            current_health = max_health;
        }
        if (max_health < 1)
        {
            max_health = 1;
        }

        healthBar_length = (Screen.width / 2) * (current_health / (float)max_health);
    }
}
