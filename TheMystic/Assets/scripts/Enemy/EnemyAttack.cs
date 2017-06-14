using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyAttack : NetworkBehaviour
{
    public GameObject closest;
    public GameObject target;   
    public Enemy_Health own;    
    public float attTimer;
    public float cooldown;
    private bool isAttacking;    
    private bool stop;
    [SerializeField]
    private int damage = 10;
    public bool Stop { get { return stop; } set { stop = value; } }
    public bool IsAttacking { get { return isAttacking; } set { isAttacking = value; } }
    public int Damage { set { damage = value; } }
    PlayerStats playerstats;

    public override void OnStartServer()
    {
        base.OnStartServer();
        if (!isServer)
            return;
        target = FindClosestEnemy();
        playerstats = target.GetComponent<PlayerStats>();        
        attTimer = 0;
        cooldown = 1.0f;
        isAttacking = false;
        stop = false;
    }

    private void Start()
    {
        own = GetComponent<Enemy_Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isServer)
            return;
        if (closest == null)
        {
            target = FindClosestEnemy();
            playerstats = target.GetComponent<PlayerStats>();
        }

        stop = own.current_health <= 0 || playerstats.currentHealth <= 0;
        if (!stop)
        {
            if (attTimer > 0)
            {
                attTimer -= Time.deltaTime;
            }
            if (attTimer <= 0)
            {
                Attack();
                attTimer = cooldown;
            }
        }   
        else
        {
            if (playerstats.currentHealth <= 0)
            {
                target = FindClosestEnemy();
                playerstats = target.GetComponent<PlayerStats>();
            }
        }
    }

    
    void Attack()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        Vector3 dir = (target.transform.position - transform.position).normalized;
        float direction = Vector3.Dot(dir, transform.forward);

        if (distance < 2.5f)
        {
            if (direction > 0)
            {
                isAttacking = true;
                RpcAttack(playerstats.gameObject);
                Debug.Log("HIT");
            }
        }
        
    }
    [ClientRpc]
    private void RpcAttack(GameObject obj)
    {
        obj.GetComponent<PlayerStats>().currentHealth -= damage;
    }
    private GameObject FindClosestEnemy()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (PlayerStats target in PlayerStats.players)
        {
            Vector3 diff = target.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = target.gameObject;
                distance = curDistance;
            }
        }
        return closest;
    }
}
