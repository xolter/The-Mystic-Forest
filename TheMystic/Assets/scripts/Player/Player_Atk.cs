using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player_Atk : MonoBehaviour
{
    public List<Skill> skills;
    public Player_Health health;
    public Player_Stamina stamina;
    public Animator anim;

    void Start()
    {
        health = GetComponent<Player_Health>();
        stamina = GetComponent<Player_Stamina>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {   if (health.current_health > 0 )
        {
            foreach (Skill s in skills)
            {
                if (Input.GetKeyDown(s.bind))
                {
                    if (s.currentCoolDown >= s.cooldown)
                    {
                        s.currentCoolDown = 0;
                        GameObject particle = s.particle;
                        Destroy(Instantiate(particle, transform.position, transform.rotation), s.cooldown);
                        //stamina.Current_Stamina -= s.manaCost;
                        PlayerStats.CurrentMana -= s.manaCost;
                    }
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
    public float manaCost;      
}