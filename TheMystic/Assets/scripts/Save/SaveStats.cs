using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveStats : MonoBehaviour {

    public GameObject player;
    PlayerStats playerstats;
    
    // Use this for initialization
	void Start ()
    {
        playerstats = GetComponent<PlayerStats>();
        if (PlayerPrefs.GetInt("load") == 1 || PlayerPrefs.GetInt("save1") == 1)
        {
            if (PlayerPrefs.GetInt("load") == 1)
            {
                float x = PlayerPrefs.GetFloat("x");
                float y = PlayerPrefs.GetFloat("y");
                float z = PlayerPrefs.GetFloat("z");
                player.transform.position = new Vector3(x, y, z);
            }

            playerstats.currentHealth = PlayerPrefs.GetFloat("CurrentHealth");
            playerstats.maxHealth = PlayerPrefs.GetInt("MaxHealth");
            playerstats.regenHealth = PlayerPrefs.GetFloat("RegenHealth");

            playerstats.currentMana = PlayerPrefs.GetFloat("CurrentMana");
            playerstats.maxMana = PlayerPrefs.GetInt("MaxMana");
            playerstats.regenMana = PlayerPrefs.GetFloat("RegenMana");

            playerstats.xp = PlayerPrefs.GetInt("Xp");
            playerstats.addXp = PlayerPrefs.GetInt("addXp");
            playerstats.maxXp = PlayerPrefs.GetInt("MaxXp");
            playerstats.Lvl = PlayerPrefs.GetInt("Lvl");

            playerstats.default_damages = PlayerPrefs.GetFloat("DefaultDamage");
            playerstats.damage = PlayerPrefs.GetFloat("Damage");
        }
       

    }
    public void Save()
    {
        PlayerPrefs.SetString("scene", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetFloat("x", player.transform.position.x);
        PlayerPrefs.SetFloat("y", player.transform.position.y);
        PlayerPrefs.SetFloat("z", player.transform.position.z);

        PlayerPrefs.SetFloat("CurrentHealth", playerstats.currentHealth);
        PlayerPrefs.SetInt("MaxHealth", playerstats.maxHealth);
        PlayerPrefs.SetFloat("RegenHealth", playerstats.regenHealth);

        PlayerPrefs.SetFloat("CurrentMana", playerstats.currentMana);
        PlayerPrefs.SetInt("MaxMana", playerstats.maxMana);
        PlayerPrefs.SetFloat("RegenMana", playerstats.regenMana);

        PlayerPrefs.SetInt("Xp", playerstats.xp);
        PlayerPrefs.SetInt("MaxXp", playerstats.maxXp);
        PlayerPrefs.SetInt("addXp", playerstats.addXp);
        PlayerPrefs.SetInt("Lvl", playerstats.Lvl);

        PlayerPrefs.SetFloat("DefaultDamage", playerstats.default_damages);
        PlayerPrefs.SetFloat("Damage", playerstats.damage);
    }
    public void ResetSaves()
    {
        PlayerPrefs.SetInt("save1", 0);
        PlayerPrefs.SetInt("load", 0);
    }

}
