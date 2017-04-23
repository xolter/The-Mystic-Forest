using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    public Image health_bar;
    public Animator anim;
    public GameObject particle;
    public int max_health = 100;
    public float current_health = 100;
    public float regen_health = 0.1f;
    private bool isDead, particlePlayed;
	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isDead", false);
        current_health = max_health;
        health_bar.fillAmount = current_health / max_health;
        isDead = particlePlayed = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        anim.SetBool("isDead", current_health <= 0);
        if (Input.GetKeyUp (KeyCode.Keypad1))
        {
            current_health -= 10;
        }
        if(Input.GetKeyUp (KeyCode.Keypad2))
        {
            current_health -= 90;
        }
        if (current_health <=40)
        {
            regen_health = 1;
        }
        else
        {
            regen_health = 0.3f;
        }
        if(current_health == max_health)
        {
            regen_health = 0;
        }
        if (current_health <= 0)
        {
            regen_health = 0;
            isDead = true;            
        }
        if (isDead && !particlePlayed)
        {
            Destroy(Instantiate(particle, transform.position, Quaternion.Euler(-90, 0, 0)), 5f);
            particlePlayed = true;
        }
        Update_currentHealth(regen_health);
        health_bar.fillAmount = current_health / max_health;
    }

    public void Update_currentHealth(float n)
    {
        current_health += n;
        if (current_health <=0)
        {
            current_health = 0;            
        }         
        if (current_health>max_health)
        {
            current_health = max_health;
        }
        if (max_health<1)
        {
            max_health = 1;
        }        
    }
}
