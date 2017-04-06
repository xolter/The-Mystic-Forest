using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;
    public Transform myTransform;
    private void Awake()
    {
        myTransform = transform;
    }
    // Use this for initialization
    void Start () {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

        myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
	}
}
