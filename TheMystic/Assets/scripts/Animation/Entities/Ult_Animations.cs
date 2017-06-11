using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ult_Animations : MonoBehaviour
{

    public Animator anim;
    public UltAtk attack;
    public Enemy_Health health;
    //public Player_Health player_health;    
    private Vector3 newpos;
    private Vector3 oldpos;
    private float fwd;
    private float strf;

    void Start()
    {
        anim = GetComponent<Animator>();
        attack = GetComponent<UltAtk>();
        health = GetComponent<Enemy_Health>();
        oldpos = GetComponent<IA>().transform.position;
        //player_health = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>();
        newpos = oldpos;
        fwd = oldpos.x;
        strf = oldpos.z;
    }

    void Update()
    {
        if (!attack.Stop)
        {
            fwd = oldpos.x - newpos.y;
            strf = oldpos.z - newpos.z;
            anim.SetFloat("Forward", fwd);
            anim.SetFloat("Strafe", strf);
            if (attack.IsAttacking)
            {
                anim.SetBool("Attack", true);
                attack.IsAttacking = false;
            }
            else
            {
                anim.SetBool("Attack", false);
            }
            if (health.current_health <= 0)
            {
                anim.SetBool("isDead", true);
            }
        }
        else
        {
            anim.SetBool("stop", true);
            if (health.current_health <= 0)
            {
                anim.SetBool("isDead", true);
            }
        }
    }
}
