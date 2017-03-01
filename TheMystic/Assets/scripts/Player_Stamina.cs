using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stamina : MonoBehaviour
{
    public int max_stamina = 100;
    public int current_stamina = 100;
    public int regen_stamina = 0;
    public float staminaBar_length;
    public GUIStyle customGUIStyle;

    // Use this for initialization
    void Start ()
    {
        staminaBar_length = 2 * max_stamina;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Update_currentStamina(regen_stamina);
	}

    void OnGUI()
    {
        GUI.color = Color.blue;
        string stamina = "";
        for (int i = 1; i < staminaBar_length; i++)
        {
            stamina += "|";
        }
        GUI.Box(new Rect(10, Screen.height - 35, staminaBar_length, 20), stamina);
    }

    public void Update_currentStamina(int n)
    {
        current_stamina += n;
        if (current_stamina < 0)
        {
            current_stamina = 0;
        }
        if(current_stamina>max_stamina)
        {
            current_stamina = max_stamina;
        }
        if(max_stamina<1)
        {
            max_stamina = 1;
        }
        staminaBar_length = (2 * max_stamina) * (current_stamina / (float)max_stamina);
    }
}
