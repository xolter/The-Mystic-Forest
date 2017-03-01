using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Stamina : MonoBehaviour
{
    public Image staminaBar;
    public int max_stamina = 100;
    public int current_stamina = 100;
    public int regen_stamina = 0;

    // Use this for initialization
    void Start ()
    {
        staminaBar.fillAmount = (float)current_stamina/max_stamina;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Update_currentStamina(regen_stamina);
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
        staminaBar.fillAmount = (current_stamina / (float)max_stamina);
    }
}
