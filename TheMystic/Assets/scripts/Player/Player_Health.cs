using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Player_Health : NetworkBehaviour
{        
    public Image health_bar;    
    public Animator anim;
    public GameObject particle;
    PlayerStats playerstats;
    [SyncVar]
    private bool isDead, particlePlayed;
	// Use this for initialization
	void Start ()
    {
        if (!isLocalPlayer)
            return;
        playerstats = GetComponent<PlayerStats>();
        anim = GetComponent<Animator>();
        anim.SetBool("isDead", false);
        health_bar.fillAmount = playerstats.currentHealth / playerstats.maxHealth;
        isDead = particlePlayed = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!isLocalPlayer)
            return;
        anim.SetBool("isDead", playerstats.currentHealth <= 0);        
        if (playerstats.currentHealth <= 0)
        {
            isDead = true;
            playerstats.regenHealth = 0;
        }
        if (isDead && !particlePlayed)
        {
            Destroy(Instantiate(particle, transform.position, Quaternion.Euler(-90, 0, 0)), 5f);
            particlePlayed = true;
        }
        Update_currentHealth(playerstats.regenHealth);
        playerstats.currentHealth = playerstats.currentHealth;
        health_bar.fillAmount =(float)playerstats.currentHealth / (float)playerstats.maxHealth;
    }

    public void Update_currentHealth(float n)
    {
        playerstats.currentHealth += n;
        if (playerstats.currentHealth <= 0)
        {
            playerstats.currentHealth = 0;
            PlayerStats.players.Remove(PlayerStats.localPlayer);
        }
        if (playerstats.currentHealth > playerstats.maxHealth)
        {
            playerstats.currentHealth = playerstats.maxHealth;
        }
    }
}
