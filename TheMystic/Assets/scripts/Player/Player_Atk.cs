﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player_Atk : MonoBehaviour
{
    public List<Skill> skills;
    void FixedUpdate()
    {       
        foreach (Skill s in skills)
        {
            if (Input.GetKeyDown(s.bind))
            {
                if(s.currentCoolDown >= s.cooldown)
                {                              
                    s.currentCoolDown = 0;                    
                    GameObject particle = s.particle;
                    Destroy(Instantiate(particle, transform.position, transform.rotation), 5f);                                                            
                }
            }
        }
    }
    void Update()
    {
        foreach(Skill s in skills)
        {
            if (s.currentCoolDown<s.cooldown)
            {
                s.currentCoolDown += Time.deltaTime;
                s.skillIcon.fillAmount = s.currentCoolDown / s.cooldown;
                
            }
        }
    }
}

[System.Serializable]
public class Skill
{
    public string name;
    public float cooldown;
    public Image skillIcon;
    public float currentCoolDown;
    public KeyCode bind;
    public GameObject particle;    
}