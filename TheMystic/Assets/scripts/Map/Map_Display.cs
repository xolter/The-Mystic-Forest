using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Display : MonoBehaviour {

    public Map_Generator generator;
    public GameObject enemy;
   // public GameObject player;
	void Start ()
    {
        generator = GameObject.FindGameObjectWithTag("Generator").GetComponent<Map_Generator>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        Display_Map();
       // Display_Player();
	}
	
    void Display_Map()
    {
        Vector3 pos = Vector3.zero;
        int k = 0;
        for (int i = 0; i < generator.Length; i++)
        {
           // k += 1;
            for (int j = 0; j < generator.Width; j++)
            {
               // k += 1;
                Instantiate( generator.map[i, j].chunk, new Vector3(i * -80, 0, j * -80), generator.map[i, j].transform.rotation);
               // if (k >= 3)
               // {
               //     k = 0;
               //     Instantiate(enemy, new Vector3(i*80 -40, 20, j*80 -40), generator.map[i,j].transform.rotation);
               // }                        
            }
        }
    }

    void Display_Player()
    {
       // Instantiate(player, new Vector3(40, 20, 40), player.transform.rotation);
    }	
}
