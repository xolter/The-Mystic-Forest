using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player_Atk : MonoBehaviour
{
    public List<Skill> skills;
    public Animator anim;
    public PlayerStats playerstats;
    public PlayerAttk basicAtk;

    void Start()
    {
        playerstats = GetComponent<PlayerStats>();
        anim = GetComponent<Animator>();
        basicAtk = GetComponent<PlayerAttk>();
    }

    void FixedUpdate()
    {   if (playerstats.currentHealth > 0 )
        {
            foreach (Skill s in skills)
            {
                if (Input.GetKeyDown(s.bind))
                {
                    if (s.currentCoolDown >= s.cooldown)
                    {
                        s.currentCoolDown = 0;
                        GameObject particle = s.particle;
                        Destroy(Instantiate(particle, transform.position, transform.rotation), s.timeEffect);
                        playerstats.currentMana -= s.manaCost;
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
                playerstats.regenHealth = 0.2f;
                //health.regen_health = 0.2f; //
                //health.Update_currentHealth(20); // 
                break;
            case ("Skill2"):
                if (skill.currentCoolDown <= skill.timeEffect)
                {
                    playerstats.damage = 1.5f * playerstats.damage;
                    basicAtk.cooldown = playerstats.autoattack_timer_default / 2;                    
                    Debug.Log("HERE");
                }
                else
                    Debuff(skill);
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
                playerstats.regenHealth = 0f;
                //health.regen_health = 0f;
                break;
            case ("Skill2"):
                {
                    playerstats.damage = playerstats.default_damages;
                    basicAtk.cooldown = playerstats.autoattack_timer_default;
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