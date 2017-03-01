using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int curHealth = 100;
    public float healthBarLength;
    public Transform target;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnGUI()
    {
    }

    public void AddjustCurrentHealth(int adj)
    {
    }
}
