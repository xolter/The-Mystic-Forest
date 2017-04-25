using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Generator : MonoBehaviour
{
    public List<Chunk> Chunks;
    Chunk[,] Map;
    //public GameObject[] Chunks;
    public int Length;
    public int Width;

	void Start ()
    {
        Map = new Chunk[Width, Length];
        Chunks = GetComponent<List<Chunk>>();
	}
          
}

