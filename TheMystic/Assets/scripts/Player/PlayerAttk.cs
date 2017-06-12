using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttk : MonoBehaviour
{
    public GameObject[] targets;
    public GameObject closest;
    public Enemy_Health target_health;
    PlayerStats playerstats;
    public float attTimer;
    public float cooldown;
    public AudioClip sound;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    // Use this for initialization
    void Start ()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
        source.volume = 0.5f;
        targets = GameObject.FindGameObjectsWithTag("Enemy");
        playerstats = GetComponent<PlayerStats>();
        //closest = FindClosestEnemy();
        attTimer = 0;
        cooldown = 0.8f;
       //---- target_health = target.GetComponent<Enemy_Health>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        targets = GameObject.FindGameObjectsWithTag("Enemy");
        if (attTimer > 0)
        {
            attTimer -= Time.deltaTime;
        }
        if (attTimer <0)
        {
            attTimer = 0;
        }
        if (Input.GetAxis("Fire1") > 0)
        {
            if (attTimer == 0)
            {
                Attack();
                attTimer = cooldown;
            }
        }
        //FindClosestEnemy();
        //target_health = closest.GetComponent<Enemy_Health>();
    }

    GameObject FindClosestEnemy()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject target in targets)
        {
            Vector3 diff = target.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = target;
                distance = curDistance;
            }
        }
        return closest;
    }

    private void Attack()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            float distance = Vector3.Distance(targets[i].transform.position, transform.position);
            Vector3 dir = (targets[i].transform.position - transform.position).normalized;
            float direction = Vector3.Dot(dir, transform.forward);
            if (distance < 2.5f)
            {
                if (playerstats.currentHealth > 0 && direction > 0)
                {
                    // Enemy_Health eh = (Enemy_Health)target.GetComponent("EnemyHealth");
                    source.PlayOneShot(sound);

                    targets[i].GetComponent<Enemy_Health>().current_health -= playerstats.damage;
                }
            }
        }
    }
}
