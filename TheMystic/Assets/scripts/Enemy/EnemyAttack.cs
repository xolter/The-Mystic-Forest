using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject target;
    public Player_Health target_health;
    public Enemy_Health own;
    public float attTimer;
    public float cooldown;
    private bool isAttacking;
    public bool IsAttacking { get { return isAttacking; } set { isAttacking = value; } }
    private bool stop;
    public bool Stop { get { return stop; } set { stop = value; } }
    private int damage;
    public int Damage { set { damage = value; } }
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        target_health = target.GetComponent<Player_Health>();
        own = GetComponent<Enemy_Health>();
        attTimer = 0;
        cooldown = 1.0f;
        isAttacking = false;
        stop = false;
        damage = 10;
    }

    // Update is called once per frame
    void Update()
    {
        stop = own.current_health <= 0 || target_health.current_health <= 0;
        if (!stop)
        {
            if (attTimer > 0)
            {
                attTimer -= Time.deltaTime;
            }
            if (attTimer < 0)
            {
                attTimer = 0;
            }
            if (attTimer == 0)
            {
                Attack();
                attTimer = cooldown;
            }
        }   
    }

    private void Attack()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        Vector3 dir = (target.transform.position - transform.position).normalized;
        float direction = Vector3.Dot(dir, transform.forward);

        if (distance < 2.5f)
        {
            if (direction > 0)
            {
                PlayerStats.currentHealth -= damage;
                isAttacking = true;
            }
        }
    }
}
