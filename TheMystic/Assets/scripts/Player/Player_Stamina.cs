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
        staminaBar.fillAmount = (float)PlayerStats.currentMana/PlayerStats.maxMana;
        //attack = GetComponent<Player_Atk>();
        access = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Update_currentStamina(regen_stamina);
        Update_currentStamina(PlayerStats.regenMana);
        //staminaBar.fillAmount = current_stamina / max_stamina;
        staminaBar.fillAmount = PlayerStats.currentMana / PlayerStats.maxMana;
    }

    public void Update_currentStamina(float n)
    {
        PlayerStats.currentMana += n;
        if (PlayerStats.currentMana < 0)
        {
            //current_stamina = 0;
            PlayerStats.currentMana = 0;
        }
        if(PlayerStats.currentMana > PlayerStats.maxMana)//current_stamina>max_stamina
        {
            //current_stamina = max_stamina;
            PlayerStats.currentMana = PlayerStats.maxMana;
        }
    }
}
