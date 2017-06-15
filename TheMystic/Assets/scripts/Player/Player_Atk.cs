using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

[System.Serializable]
public class Player_Atk : NetworkBehaviour
{
    public List<Skill> skills;
    public Animator anim;
    public PlayerStats playerstats;
    public PlayerAttk basicAtk;

    private Skill GetSkill(int id)
    {
        return skills.Find(skill => skill.id == id);
    }

    void Start()
    {

        playerstats = GetComponent<PlayerStats>();
        anim = GetComponent<Animator>();
        basicAtk = GetComponent<PlayerAttk>();
        InitSounds();
    }
    void InitSounds()
    {
        foreach (Skill skill in skills)
        {
            switch (skill.name)
            {
                case ("Skill1"):
                    skill.audiosource = GameObject.FindGameObjectWithTag("SoundSkill1").GetComponent<AudioSource>();
                    break;
                case ("Skill2"):
                    skill.audiosource = GameObject.FindGameObjectWithTag("SoundSkill2").GetComponent<AudioSource>();
                    break;
                case ("Skill3"):
                    skill.audiosource = GameObject.FindGameObjectWithTag("SoundSkill3").GetComponent<AudioSource>();
                    break;
                case ("Skill4"):
                    skill.audiosource = GameObject.FindGameObjectWithTag("SoundSkill4").GetComponent<AudioSource>();
                    break;
                default:
                    break;
            }
        }
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer)
            return;
        if (playerstats.currentHealth > 0 )
        {
            foreach (Skill s in skills)
            {
                if (Input.GetKeyDown(s.bind))
                {
                    if (s.currentCoolDown >= s.cooldown && (playerstats.currentMana - s.manaCost) >= 0)
                    {
                        s.currentCoolDown = 0;                        
                        playerstats.currentMana -= s.manaCost;
                        s.audiosource.Play();
                        if(isServer)
                        {
                            SpawnParticles(s.id);
                        }
                        else
                        {
                            CmdSpawnParticles(s.id);
                        }

                    }
                }
            }
        }
    }
    [Command]
    void CmdSpawnParticles(int id)
    {
        SpawnParticles(id);
    }
    void SpawnParticles(int id)
    {
        Skill s = GetSkill(id);
        GameObject particle = s.particle;
        var temp = (GameObject)Instantiate(particle, transform.position, transform.rotation);
        NetworkServer.Spawn(temp);
        Destroy(temp, s.timeEffect);
    }


    void Update()
    {
        if (!isLocalPlayer)
            return;
        foreach (Skill s in skills)
        {
            if (s.currentCoolDown < s.cooldown)
            {
                s.currentCoolDown += Time.deltaTime;
                s.skillIcon.fillAmount = s.currentCoolDown / s.cooldown;
                Buff(s.id);
            }           
            else if (s.currentCoolDown >= s.cooldown)
            {
                Debuff(s.id);
            } 
        }        
    }

    private void Buff(int id)
    {
        Skill skill = GetSkill(id);
        switch (id)
        {
            case 1:
                playerstats.regenHealth = playerstats.Skill1Points * 0.2f;
                break;
            case 2:               
                if (skill.currentCoolDown <= skill.timeEffect)
                {
                    playerstats.damage = playerstats.Skill2Points * 15 + playerstats.default_damages; // j'ai changé ici 
                    basicAtk.cooldown = playerstats.autoattack_timer_default / 2;
                }
                else
                    Debuff(id);
                break;
            case 3:                ;
                if (skill.currentCoolDown <= skill.timeEffect)
                {
                    playerstats.moveSpeed = playerstats.Skill3Points * 0.5f * playerstats.defaultMoveSpeed + playerstats.defaultMoveSpeed;
                }
                break;
            case 4:
                break;
            default:
                break;
        }
    }

    private void Debuff(int id)
    {
        switch (id)
        {
            case 1:
                playerstats.regenHealth = 0f;
                //health.regen_health = 0f;
                break;
            case 2:
                playerstats.damage = playerstats.default_damages;
                basicAtk.cooldown = playerstats.autoattack_timer_default;
                break;
            case 3:
                playerstats.moveSpeed = playerstats.defaultMoveSpeed;
                break;
            case 4:
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
    public int id;
    public float cooldown;
    public Image skillIcon;
    public float currentCoolDown;
    public KeyCode bind;    
    public GameObject particle;
    public float manaCost;
    public float timeEffect;
    public AudioSource audiosource;

}