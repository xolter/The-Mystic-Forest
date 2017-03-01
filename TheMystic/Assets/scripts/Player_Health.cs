using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public int max_health = 100;
    public int current_health = 100;
    public int regen_health = 0;
    public float healthBar_length;
    public GUIStyle customGUIStyle;
	// Use this for initialization
	void Start ()
    {
        healthBar_length = 2*max_health;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Update_currentHealth(regen_health);	
	}

    void OnGUI()
    {
        GUI.color = Color.red;
        string health = "";
        for (int i = 1; i < healthBar_length; i++)
        {
            health += "|";
        }
        GUI.Box(new Rect(10, Screen.height-70, healthBar_length, 20), health);
        
    }

    public void Update_currentHealth(int n)
    {
        current_health += n;
        if (current_health <0)
        {
            current_health = 0;
        }         
        if (current_health>max_health)
        {
            current_health = max_health;
        }
        if (max_health<1)
        {
            max_health = 1;
        }

        healthBar_length = (2*max_health) * (current_health / (float)max_health);
    }
}
