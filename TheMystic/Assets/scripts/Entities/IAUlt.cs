using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class IAUlt : NetworkBehaviour
{
    public List<GameObject> targets;
    public GameObject closest;
    public GameObject self;
    public Transform target;
    public Transform myTransform;
    public Enemy_Health health;
    public float difdistance;
    public int moveSpeed;
    public int rotationSpeed;

    private void Awake()
    {
        myTransform = transform;
    }

    void Start ()
    {        
        health = GetComponent<Enemy_Health>();
        self = gameObject;
        difdistance = 2.5f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!isServer)
            return;
        targets = FindTargets();
        closest = FindClosestEnemy();
        if (closest == null)
            closest = PlayerStats.localPlayer.gameObject;
        target = closest.transform;
		if (health.current_health > 0 && closest.GetComponent<Enemy_Health>().current_health > 0)
        {
            Vector3 b = Vector3.zero;
            b.x = (target.position.x - myTransform.position.x);
            b.z = (target.position.z - myTransform.position.z);
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(b), rotationSpeed*Time.deltaTime);
            if(Vector3.Distance(target.position, myTransform.position) > difdistance)
            {
                myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
            }
        }
        else if (closest.GetComponent<Enemy_Health>().current_health <= 0)
        {
            targets = FindTargets();
            closest = FindClosestEnemy();
            while (closest.name == "Portal")
                closest = FindClosestEnemy();
        }
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
    private List<GameObject> FindTargets()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Enemy");
        if (temp.Length > 0)
        {
            targets = new List<GameObject>();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].name != "Portal")
                    targets.Add(temp[i]);
            }
        }
            return targets;        
    }
}
