using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Stamina : MonoBehaviour
{
    public Image staminaBar;
    public Player_Atk attack;
    //public int max_stamina;
    //private float current_stamina;
    //public float Current_Stamina { get { return current_stamina; } set { current_stamina = value; } }
    //public float regen_stamina;
    bool access; 

    // Use this for initialization
    void Start ()
    {
        //max_stamina = PlayerStats.MaxStamina;
        //regen_stamina = PlayerStats.RegenStamina;
        //staminaBar.fillAmount = (float)current_stamina/max_stamina;
        //current_stamina = PlayerStats.CurrentMana;
        staminaBar.fillAmount = (float)PlayerStats.CurrentMana/PlayerStats.MaxMana;
        //attack = GetComponent<Player_Atk>();
        access = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Update_currentStamina(regen_stamina);
        Update_currentStamina(PlayerStats.RegenMana);
        //staminaBar.fillAmount = current_stamina / max_stamina;
        staminaBar.fillAmount = PlayerStats.CurrentMana / PlayerStats.MaxMana;
    }

    public void Update_currentStamina(float n)
    {
        PlayerStats.CurrentMana += n;
        if (PlayerStats.CurrentMana < 0)
        {
            //current_stamina = 0;
            PlayerStats.CurrentMana = 0;
        }
        if(PlayerStats.CurrentMana > PlayerStats.MaxMana)//current_stamina>max_stamina
        {
            //current_stamina = max_stamina;
            PlayerStats.CurrentMana = PlayerStats.MaxMana;
        }
    }
}
