using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;
    public Transform myTransform;
    public float difdistance;
    private void Awake()
    {
        myTransform = transform;
    }
    // Use this for initialization
    void Start () {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
        difdistance = 2.5f;
	}
	
	// Update is called once per frame
	void Update ()
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
