using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Exp : MonoBehaviour {

    public Image ExpBar;
    public Text ScoreText;
    PlayerStats playerstats;

    void Start ()
    {
        playerstats = GetComponent<PlayerStats>();
        ExpBar.fillAmount = (float)playerstats.xp / playerstats.maxXp;
    }
	
	void Update ()
    {
        ExpBar.fillAmount = (float)playerstats.xp / playerstats.maxXp;
        ScoreText.text = playerstats.Lvl.ToString();
    }
    public void Update_EXP()
    {
        playerstats.xp += playerstats.addXp;
        if (playerstats.xp >= playerstats.maxXp)
        {
            UP_LVL();
        }
    }
    public void UP_LVL()
    {
        playerstats.Lvl += 1;
        playerstats.currentHealth = playerstats.maxHealth;
        playerstats.currentMana = playerstats.maxMana;
        playerstats.xp = 0;

    }
}
