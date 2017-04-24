using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    public GameObject target;
    public Player_Health target_health;
    public float attTimer;
    public float cooldown;
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        target_health = target.GetComponent<Player_Health>();
        attTimer = 0;
        cooldown = 1.0f;
    }

    // Update is called once per frame
    void Update()
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

    private void Attack()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        Vector3 dir = (target.transform.position - transform.position).normalized;
        float direction = Vector3.Dot(dir, transform.forward);

        if (distance < 2.5f)
        {
            if (direction > 0)
            {                
                target_health.Update_currentHealth(-10);
                Debug.Log("HIT HERO");
            }
        }
    }
}
