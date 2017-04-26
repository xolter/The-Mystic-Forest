using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon_Loader : MonoBehaviour {
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Application.LoadLevel("ForestDungeon");            
        }
    }

}
