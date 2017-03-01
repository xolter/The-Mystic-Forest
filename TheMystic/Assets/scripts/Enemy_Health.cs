using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Health : MonoBehaviour
{
    public Image healthbar;
    public int max_health = 100;
    public int current_health = 100;
    public int regen_health = 0;

    // Use this for initialization
    void Start()
    {
        healthbar.fillAmount = (float)current_health / max_health;
    }

    // Update is called once per frame
    void Update()
    {
        Update_currentHealth(regen_health);
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

        healthbar.fillAmount = (float)current_health / max_health;
    }
}
