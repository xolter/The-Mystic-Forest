using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    public Image health_bar;
    public Animator anim;
    public GameObject particle;

    private bool isDead, particlePlayed;
    PlayerStats playerstats;

	// Use this for initialization
	void Start ()
    {
        playerstats = GetComponent<PlayerStats>();
        anim = GetComponent<Animator>();
        anim.SetBool("isDead", false);
        health_bar.fillAmount = playerstats.currentHealth / playerstats.maxHealth;
        isDead = particlePlayed = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
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
        }
        if (playerstats.currentHealth > playerstats.maxHealth)
        {
            playerstats.currentHealth = playerstats.maxHealth;
        }
    }
}
