using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    public Image health_bar;
    public Animator anim;
    public GameObject particle;
    //public int max_health = 100;
    //public float current_health = 100;
    //public float regen_health = 0.1f;
    public int max_health;
    public float current_health;
    //public float regen_health;
    private bool isDead, particlePlayed;
	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isDead", false);
        //current_health = max_health = PlayerStats.maxHealth;
        health_bar.fillAmount = PlayerStats.currentHealth / PlayerStats.maxHealth;
        //regen_health = PlayerStats.regenHealth;
        isDead = particlePlayed = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        anim.SetBool("isDead", PlayerStats.currentHealth <= 0);        
        if (PlayerStats.currentHealth <= 0)
        {
            isDead = true;
            PlayerStats.regenHealth = 0;
        }
        if (isDead && !particlePlayed)
        {
            Destroy(Instantiate(particle, transform.position, Quaternion.Euler(-90, 0, 0)), 5f);
            particlePlayed = true;
        }
        //PlayerStats.currentHealth = current_health;
        Update_currentHealth(PlayerStats.regenHealth);
        health_bar.fillAmount =(float)PlayerStats.currentHealth / (float)PlayerStats.maxHealth;
        Debug.Log("Gur LIFE = " + PlayerStats.currentHealth);
    }

    public void Update_currentHealth(float n)
    {
        PlayerStats.currentHealth += n;
        Debug.Log("REGEN= " + n);
        if (current_health <=0)
        {
            current_health = PlayerStats.currentHealth = 0;            
        }         
        if (PlayerStats.currentHealth>PlayerStats.maxHealth)
        {
            PlayerStats.currentHealth = PlayerStats.maxHealth;
        }
        //PlayerStats.CurrentHealth = current_health;
    }
}
