using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    public Animator anim;
    private float inputH;
    private float inputV;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetFloat("inputH", 0);
        anim.SetFloat("inputV", 0);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.Play("Skill1", -1, 0f);
        }
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        anim.SetFloat("InputH", inputH);
        anim.SetFloat("InputV", inputV);
        Debug.Log(inputH + "~~" +inputV);        
    }
}
