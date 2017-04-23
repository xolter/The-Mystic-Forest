using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Stamina : MonoBehaviour
{
    public Image staminaBar;
    public Player_Atk attack;
    public int max_stamina;
    private float current_stamina;
    public float Current_Stamina { get { return current_stamina; } set { current_stamina = value; } }
    public float regen_stamina;
    bool access; 

    // Use this for initialization
    void Start ()
    {
        max_stamina = 100;
        regen_stamina = 0.5f;
        current_stamina = max_stamina;
        staminaBar.fillAmount = (float)current_stamina/max_stamina;
        attack = GetComponent<Player_Atk>();
        access = false;
	}
	
	// Update is called once per frame
	void Update ()
    {        
        Update_currentStamina(regen_stamina);
        staminaBar.fillAmount = current_stamina / max_stamina;
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
    }
}
