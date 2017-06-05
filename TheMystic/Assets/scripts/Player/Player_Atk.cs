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
                        PlayerStats.currentMana -= s.manaCost;
                    }
                }
            }
        }
    }
    void Update()
    {
        foreach (Skill s in skills)
        {
            if (s.currentCoolDown < s.cooldown)
            {
                s.currentCoolDown += Time.deltaTime;
                s.skillIcon.fillAmount = s.currentCoolDown / s.cooldown;
                Buff(s);            
            }           
            else if (s.currentCoolDown >= s.cooldown)
            {
                Debuff(s);
            } 
        }        
    }

    public void Buff(Skill skill)
    {
        switch (skill.name)
        {
            case ("Skill1"):
                PlayerStats.regenHealth = 0.2f;
                break;
            case ("Skill2"):
                if (skill.currentCoolDown <= skill.timeEffect)
                {
                    //Debug.Log();
                    PlayerStats.damage = 3 * PlayerStats.damage;
                    //skill.trigered = false;
                }
                break;
            case ("Skill3"):
                break;
            case ("Skill4"):
                break;
            default:
                break;
        }
    }
    public void Debuff(Skill skill)
    {
        switch (skill.name)
        {
            case ("Skill1"):
                PlayerStats.regenHealth = 0f;
                break;
            case ("Skill2"):
                PlayerStats.damage = PlayerStats.default_damages;
                break;
            case ("Skill3"):
                break;
            case ("Skill4"):
                break;
            default:
                break;
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
    public float timeEffect;
}