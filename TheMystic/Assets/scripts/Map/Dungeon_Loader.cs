using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon_Loader : MonoBehaviour
{
    public Collider other;
    void Start()
    {
        other = GetComponent<Collider>();    
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Application.LoadLevel("ForestDungeon");            
        }
    }

}
