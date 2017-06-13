using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerStats : NetworkBehaviour
{           
    public float currentHealth { get; set; }
    public int maxHealth { get; set; }
    public int minHealth { get; set; }
    public float regenHealth { get; set; }

    public float currentMana { get; set; }
    public int maxMana { get; set; }
    public int minMana { get; set; }
    public float regenMana { get; set; }

    public int xp { get; set; }
    public int maxXp { get; set; }
    public int addXp { get; set; }
    public int Lvl { get; set; }

    public float default_damages { get; set; }
    public float damage { get; set; }
    public float autoattack_timer_default { get; set; }
    public static PlayerStats localPlayer;
    public static List<PlayerStats> players = new List<PlayerStats>();  


    public PlayerStats()
    {
        currentHealth = 100;
        maxHealth = 100;
        minHealth = 0;
        regenHealth = 0;

        currentMana = 100;
        maxMana = 100;
        minMana = 100;
        regenMana = 0.02f;

        xp = 0;
        maxXp = 100;
        addXp = 50;
        Lvl = 1;

        default_damages = 10f;
        damage = 10f;
        autoattack_timer_default = 0.8f;
        
    }

    public override void OnStartLocalPlayer()
    {
        localPlayer = this;
    }

    private void Start()
    {
        players.Add(this);
    }
}
