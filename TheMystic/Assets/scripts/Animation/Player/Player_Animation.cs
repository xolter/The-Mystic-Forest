using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player_Animation : NetworkBehaviour
{
    public Animator anim;
    public Player_Atk attack;
    private float inputH;
    private float inputV;
    private float inputJ;
    private float inputAutoAttackL;
    private float inputAutoAttackR;

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
        if (!isLocalPlayer)
            return;
        foreach (Skill s in attack.skills)
        {
            if (anim.IsInTransition(0))
            {
                anim.SetBool(s.name, false);
            }
            else if (Input.GetKeyDown(s.bind) && !anim.GetBool(s.name) && s.currentCoolDown <= 0.1f)
            {                               
                    anim.SetBool(s.name, true);                
            }
        }
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        inputJ = Input.GetAxis("Jump");
        inputAutoAttackL = Input.GetAxis("Fire1");
        inputAutoAttackR = Input.GetAxis("Fire2");
        anim.SetFloat("InputH", inputH);
        anim.SetFloat("InputV", inputV);
        anim.SetFloat("InputJ", inputJ);
        anim.SetFloat("InputAA", inputAutoAttackL);
        anim.SetFloat("InputAA2", inputAutoAttackR);            
    }
}
