using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    public Animator anim;
    private float inputH;
    private float inputV;
    private float inputJ;
    private float inputAutoAttack;
    private bool Skill1;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetFloat("InputH", 0);
        anim.SetFloat("InputV", 0);
        anim.SetFloat("InputJ", 0);
        anim.SetFloat("InputAA", 0);
        anim.SetBool("Skill1", false);        
    }


    void Update()
    {
        Skill1 = Input.GetKeyDown(KeyCode.A);        
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        inputJ = Input.GetAxis("Jump");
        inputAutoAttack = Input.GetAxis("Fire1");
        anim.SetFloat("InputH", inputH);
        anim.SetFloat("InputV", inputV);
        anim.SetFloat("InputJ", inputJ);
        anim.SetFloat("InputAA", inputAutoAttack);
        anim.SetBool("Skill1", Skill1);
    }
}
