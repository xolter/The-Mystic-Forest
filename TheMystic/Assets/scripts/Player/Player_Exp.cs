using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Exp : MonoBehaviour {

    public Image ExpBar;
    public int xp;

    void Start ()
    {
        ExpBar.fillAmount = (float)PlayerStats.xp / PlayerStats.maxXp;
        xp = PlayerStats.xp;
    }
	
	void Update ()
    {
        ExpBar.fillAmount = (float)xp / PlayerStats.maxXp;
        PlayerStats.xp = xp;
    }
    public void Update_EXP()
    {
        xp += PlayerStats.addXp;
        if (xp >= PlayerStats.maxXp)
        {
            UP_LVL();
        }
    }
    public void UP_LVL()
    {
        PlayerStats.Lvl += 1;
        PlayerStats.currentHealth = PlayerStats.maxHealth;
        PlayerStats.currentMana = PlayerStats.maxMana;
        xp = 0;

    }
}
