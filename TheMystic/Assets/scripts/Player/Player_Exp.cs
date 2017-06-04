using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Exp : MonoBehaviour {

    public Image ExpBar;
    public int xp;

    void Start ()
    {
        ExpBar.fillAmount = (float)PlayerStats.Xp / PlayerStats.MaxXp;
        xp = PlayerStats.Xp;
    }
	
	void Update ()
    {
        ExpBar.fillAmount = (float)xp / PlayerStats.MaxXp;
        PlayerStats.Xp = xp;
    }
    public void Update_EXP()
    {
        xp += PlayerStats.addXp;
        if (xp >= PlayerStats.MaxXp)
        {
            UP_LVL();
        }
    }
    public void UP_LVL()
    {
        PlayerStats.Lvl += 1;
        PlayerStats.CurrentHealth = PlayerStats.MaxHealth;
        PlayerStats.CurrentMana = PlayerStats.MaxMana;
        xp = 0;

    }
}
