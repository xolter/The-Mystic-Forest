using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Stamina : MonoBehaviour
{
    public Image staminaBar;
    PlayerStats playerstats;
    bool access; 

    // Use this for initialization
    void Start ()
    {
        playerstats = GetComponent<PlayerStats>();
        staminaBar.fillAmount = (float)playerstats.currentMana/playerstats.maxMana;
        access = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Update_currentStamina(regen_stamina);
        Update_currentStamina(playerstats.regenMana);
        staminaBar.fillAmount = playerstats.currentMana / playerstats.maxMana;
    }

    public void Update_currentStamina(float n)
    {
        playerstats.currentMana += n;
        if (playerstats.currentMana < 0)
        {
            playerstats.currentMana = 0;
        }
        if(playerstats.currentMana > playerstats.maxMana)
        {
            playerstats.currentMana = playerstats.maxMana;
        }
    }
}
