using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    public Animator anim;
    public Player_Atk attack;
    private float inputH;
    private float inputV;
    private float inputJ;
    private float inputAutoAttack;

    void Start()
    {
        anim = GetComponent<Animator>();
        attack = GetComponent<Player_Atk>();
        anim.SetFloat("InputH", 0);
        anim.SetFloat("InputV", 0);
        anim.SetFloat("InputJ", 0);
        anim.SetFloat("InputAA", 0);
        foreach (Skill s in attack.skills)
        {
            anim.SetBool(s.name, false);
        }                
    }


    void Update()
    {    
        foreach (Skill s in attack.skills)
        {
            if (anim.IsInTransition(0))
            {
                anim.SetBool(s.name, false);
            }
            if (Input.GetKeyDown(s.bind) && !anim.GetBool(s.name))
            {                               
                    anim.SetBool(s.name, true);                
            }
        }
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        inputJ = Input.GetAxis("Jump");
        inputAutoAttack = Input.GetAxis("Fire1");
        anim.SetFloat("InputH", inputH);
        anim.SetFloat("InputV", inputV);
        anim.SetFloat("InputJ", inputJ);
        anim.SetFloat("InputAA", inputAutoAttack);             
    }
}
