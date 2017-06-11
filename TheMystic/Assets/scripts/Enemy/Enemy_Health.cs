using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Health : MonoBehaviour
{
    public Image healthbar;
    public float max_health = 100;
    public float current_health = 100;
    //public int Current_Health { get { return current_health; } set { current_health = value; } }
    public float regen_health = 0f;
    private bool xpGiven = false;
    public GameObject target;
    Player_Exp target_xp;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        healthbar.fillAmount = (float)current_health / max_health;
        target_xp = target.GetComponent<Player_Exp>();
    }

    // Update is called once per frame
    void Update()
    {
        Update_currentHealth(regen_health);
        healthbar.fillAmount = (float)current_health / max_health;
    }

    public void Update_currentHealth(float n)
    {
        current_health += n;
        if (current_health <= 0)
        {
            current_health = 0;
            if (!xpGiven)
            {
                target_xp.Update_EXP();
                xpGiven = true;
            }
        }
        if (current_health > max_health)
        {
            current_health = max_health;
        }
        if (max_health < 1)
        {
            max_health = 1;
        }
    }
}
