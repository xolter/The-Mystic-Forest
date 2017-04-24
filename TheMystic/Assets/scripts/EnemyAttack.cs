using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    public GameObject target;
    public float attTimer;
    public float cooldown;
    // Use this for initialization
    void Start()
    {
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
                Player_Health eh = (Player_Health)target.GetComponent("PlayerHealth");
                eh.Update_currentHealth(-10);
            }
        }
    }
}
