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
    private bool Skill1;

    void Start()
    {
        anim = GetComponent<Animator>();
        attack = GetComponent<Player_Atk>();
        anim.SetFloat("InputH", 0);
        anim.SetFloat("InputV", 0);
        anim.SetFloat("InputJ", 0);
        anim.SetFloat("InputAA", 0);
        anim.SetBool("Skill1", false);        
    }


    void Update()
    {
        //Skill1 = Input.GetKeyDown(KeyCode.A);        
        foreach (Skill S in attack.skills)
        {
            anim.SetBool(S.name, S.currentCoolDown > 0.1f && S.currentCoolDown < 0.2f);
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
