using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    public Transform target;
    public Enemy_Health health;
    public GameObject self;
    public int moveSpeed;
    public int rotationSpeed;
    public Transform myTransform;
    public float difdistance;
    PlayerStats playerstats;
    private void Awake()
    {
        myTransform = transform;
    }
    // Use this for initialization
    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        playerstats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        health = GetComponent<Enemy_Health>();        
        difdistance = 2.5f;
        self = GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health.current_health > 0 && playerstats.currentHealth > 0)
        {
            Vector3 b = Vector3.zero;
            b.x = (target.position.x - myTransform.position.x);
            b.z = (target.position.z - myTransform.position.z);
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(/*target.position - myTransform.position*/ b), rotationSpeed * Time.deltaTime);
            if (Vector3.Distance(target.position, myTransform.position) > difdistance)
            {
                myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
            }
        }
    }
}
