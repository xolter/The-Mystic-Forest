using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltAtk : MonoBehaviour
{
    public List<GameObject> targets;
    public GameObject closest;
    public GameObject target;
    public Enemy_Health own;
    public float attTimer;
    public float cooldown;
    private bool isAttacking;
    public bool IsAttacking { get { return isAttacking; } set { isAttacking = value; } }
    private bool stop;
    public bool Stop { get { return stop; } set { stop = value; } }
    private int damage;
    public int Damage { set { damage = value; } }

    void Start()
    {
        targets = FindTargets();
        target = FindClosestEnemy();        
        own = GetComponent<Enemy_Health>();
        attTimer = 0;
        cooldown = 1.0f;
        isAttacking = false;
        stop = false;
        damage = 10;
        for (int i = 0; i < targets.Count; i++)
            Debug.Log("name: " + targets[i].name);
    }


    void Update()
    {
        targets = FindTargets();
        target = FindClosestEnemy();
        stop = own.current_health <= 0 || target.GetComponent<Enemy_Health>().current_health <= 0;
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
        else
        {
            if (target.GetComponent<Enemy_Health>().current_health <= 0)
            {
                targets = FindTargets();
                target = FindClosestEnemy();
            }
        }
    }

    private void Attack()
    {
        foreach(GameObject target in targets)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);
            Vector3 dir = (target.transform.position - transform.position).normalized;
            float direction = Vector3.Dot(dir, transform.forward);
            if (distance < 2.5f)
            {
                if (direction > 0)
                {
                    // Enemy_Health eh = (Enemy_Health)target.GetComponent("EnemyHealth");                    
                    target.GetComponent<Enemy_Health>().current_health -= 10;
                    isAttacking = true;
                }
            }
        }
    }
    private GameObject FindClosestEnemy()
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
    private List<GameObject> FindTargets()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Enemy");
        targets = new List<GameObject>();
        for(int i=0; i < temp.Length; i++)
        {
            if (temp[i].name != "Portal")
                targets.Add(temp[i]);
        }
        return targets;
    }
}
