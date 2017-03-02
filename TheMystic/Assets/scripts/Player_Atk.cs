using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player_Atk : MonoBehaviour
{
    public List<Skill> skills;
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (skills[0].currentCoolDown >= skills[0].cooldown)
            {
                //cast a spell
                skills[0].currentCoolDown = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (skills[1].currentCoolDown >= skills[1].cooldown)
            {
                //cast a spell
                skills[1].currentCoolDown = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (skills[2].currentCoolDown >= skills[2].cooldown)
            {
                //cast a spell
                skills[2].currentCoolDown = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            
            if (skills[3].currentCoolDown >= skills[3].cooldown)
            {
                //cast a spell
                skills[3].currentCoolDown = 0;
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
    public float cooldown;
    public Image skillIcon;
    public float currentCoolDown;
}