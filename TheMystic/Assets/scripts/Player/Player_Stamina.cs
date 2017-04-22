using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Stamina : MonoBehaviour
{
    public Image staminaBar;
    public int max_stamina;
    public float current_stamina;
    public float regen_stamina;

    // Use this for initialization
    void Start ()
    {
        max_stamina = 100;
        regen_stamina = 0.5f;
        current_stamina = max_stamina;
        staminaBar.fillAmount = (float)current_stamina/max_stamina;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            current_stamina -= 10;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            current_stamina -= 20;
        }
        if(Input.GetKeyUp(KeyCode.R))
        {
            current_stamina -= 50;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            current_stamina -= 90;
        }
        Update_currentStamina(regen_stamina);
	}

    public void Update_currentStamina(float n)
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
        staminaBar.fillAmount = current_stamina / max_stamina;
    }
}
