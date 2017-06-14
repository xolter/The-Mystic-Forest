using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMap : MonoBehaviour {

    Map_Generator2 mapgen2;
    //GameObject generator;
    Chunk[,] map;

	void Start ()
    {
        //generator = GameObject.FindGameObjectWithTag("Generator");
	}
	
    public void Savemap()
    {
        mapgen2 = GetComponent<Map_Generator2>();
        map = Map_Generator2.map;

        string position;
        string mapname;
        int ligne = map.GetLength(0);
        int colonne = map.GetLength(1);
        for (int i = 0; i < ligne; i++)
        {
            for (int j = 0; j < colonne; j++)
            {
                position = "[" + i + "," + j + "]";
                mapname = map[i, j].name;
                PlayerPrefs.SetString(position, mapname);
            }
        }
    }
}
