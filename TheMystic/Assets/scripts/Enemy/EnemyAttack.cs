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
        Debug.Log("1");
        if (!isServer)
            return;
        Debug.Log("2");

        if (closest == null)
        {
            target = FindClosestEnemy();
            playerstats = target.GetComponent<PlayerStats>();
        }

        stop = own.current_health <= 0 || playerstats.currentHealth <= 0;
        Debug.Log("3");
        if (!stop)
        {
            Debug.Log("4");
            if (attTimer > 0)
            {
                attTimer -= Time.deltaTime;
                Debug.Log("5");
            }
            if (attTimer < 0)
            {
                attTimer = 0;
                Debug.Log("6");
            }
            if (attTimer == 0)
            {
                Attack();
                attTimer = cooldown;
                Debug.Log("7");
            }
        }   
        else
        {
            Debug.Log("8");
            if (playerstats.currentHealth <= 0)
            {
                Debug.Log("9");
                target = FindClosestEnemy();
                Debug.Log("10");
                playerstats = target.GetComponent<PlayerStats>();
                Debug.Log("11");
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
                Debug.Log("HERE");
            }
        }
        
    }
    [ClientRpc]
    private void RpcAttack(GameObject obj)
    {
        obj.GetComponent<PlayerStats>().currentHealth = obj.GetComponent<PlayerStats>().currentHealth - damage;
        Debug.Log("LIFE: " + obj.GetComponent<PlayerStats>().currentHealth);
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
