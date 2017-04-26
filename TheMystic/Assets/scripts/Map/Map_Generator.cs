using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Generator : MonoBehaviour
{
    public List<Chunk> Chunks;
    Chunk[,] map;    
    public int Length;
    public int Width;

	void Start ()
    {
        MapInit();
        Generator();    
        InGameDisplay();
	}
    
    void MapInit()
    {
        map = new Chunk[Length, Width];
        for (int i = 0; i < Length; i++)
            for (int j = 0; j < Width; j++)
                map[i, j] = null;                                    
    }

    void Generator()
    {
        map[0, 0] = Chunks[(int)ChunkType.TLcorner];                                                       
//        Debug.Log("0, 0 " + map[0,0].type);                                                              
        List<Chunk> possible = new List<Chunk>();
        for (int j = 1; j < Width - 1; j++)                                                               
        {                                                                                                 
            possible = new List<Chunk>();                                                                 
            foreach (Chunk c in Chunks)                                                                   
            {                                                                                    
                if (c.neighboorsL.Contains(map[0, j - 1].chunk) && c.neighboorsU.Count == 5)              
                {                                                                                         
                    possible.Add(c);                                                                      
                }                                                                                         
            }                                                                                             
            map[0, j] = possible[Random.Range(0, possible.Count - 1)];                                    
//            Debug.Log("0, " + j + " "  + map[0, j].type);                                                            
        }
        possible = new List<Chunk>();
        if (Chunks[(int)ChunkType.TRcorner].neighboorsL.Contains(map[0, Width-2].chunk))
        {
            map[0, Width - 1] = Chunks[(int)ChunkType.TRcorner];
        }
        else
        {
            map[0, Width - 1] = Chunks[11];
        }
//        Debug.Log("0, " + (Width -1)+ " " + map[0, Width -1].type);
        for (int i = 1; i < Length - 1; i++)                                                          //2eme ligne à avant derniere ligne
        {
            Debug.Log("i,j: " + (i - 1) + ", 0  U: " + map[i - 1, 0].type);
            possible = new List<Chunk>();            
            foreach (Chunk c in Chunks)                                                               //premiere colonne
            {                                
                if (c.neighboorsU.Contains(map[i - 1, 0].chunk) && c.neighboorsL.Count == 5)
                {
                    possible.Add(c);
                    Debug.Log("type:" + c.type);
                }
            }
            Debug.Log("COUNT: " + possible.Count);
            map[i, 0] = possible[Random.Range(0, possible.Count - 1)];
 //           Debug.Log(i + ", 0 " + map[i, 0].type);
            possible = new List<Chunk>();
            for (int j = 1; j < Width - 1; j++)                                                       //2eme colonne à avant derniere colonne
            {                
                foreach(Chunk c in Chunks)
                {
                    if (c.neighboorsL.Contains(map[i,j-1].chunk) && c.neighboorsU.Contains(map[i-1, j].chunk))
                    {
                        possible.Add(c);
                    }
                }
                map[i, j] = possible[Random.Range(0, possible.Count - 1)];
 //               Debug.Log(i + ", " + j + ": " + map[i, j].type);            
            }
            possible = new List<Chunk>();                                                                      //derniere colonne
            foreach (Chunk c in Chunks)
            {
                if (c.neighboorsU.Contains(map[i - 1, Width - 1].chunk) && c.neighboorsL.Contains(map[i, Width - 2].chunk) && c.neighboorsR.Count == 5)
                {
                    possible.Add(c);
                }
            }                        
            if (possible.Count > 0)
            {
                map[i, Width - 1] = possible[Random.Range(0, possible.Count - 1)];
            }            
            else
            {
                map[i, Width - 1] = Chunks[11];               
            }
 //           Debug.Log(i + ", " + (Width-1) + ": " + map[i, Width-1].type);
        }
        possible = new List<Chunk>();
        
        if (Chunks[(int)ChunkType.BLcorner].neighboorsU.Contains(map[Length - 2, 0].chunk))
        {
            map[Length - 1, 0] = Chunks[(int)ChunkType.BLcorner];
        }      
        else
        {
            map[Length -1, 0] = Chunks[11];               
        }
 //       Debug.Log(Length - 1 + ",0: " + map[Length - 1, 0].type);                                           
        possible = new List<Chunk>();
        for (int j = 1; j < Width - 1; j++)                                                                    //derniere ligne, c2- avant derniere colonne
        {
            possible = new List<Chunk>();
            foreach (Chunk c in Chunks)
            {               
                if (c.neighboorsL.Contains(map[Length -1, j - 1].chunk) && c.neighboorsU.Contains(map[Length - 2, j].chunk) && c.neighboorsD.Count == 5)
                {
                    possible.Add(c);
                }
            }
            possible.Remove(Chunks[(int)ChunkType.BLcorner]);
            if (possible.Count > 0)
            {
                map[Length - 1, j] = possible[Random.Range(0, possible.Count - 1)];
            }
            else
            {
                map[Length - 1, j] = Chunks[11];
            }
//            Debug.Log((Length - 1) + ", " + j + ": " + map[Length - 1, j].type);
        }
        possible = new List<Chunk>();
        if (Chunks[(int)ChunkType.BRcorner].neighboorsU.Contains(map[Length - 2, 0].chunk))
        {
            map[Length - 1, Width -1] = Chunks[(int)ChunkType.BRcorner];
        }
        else
        {
            map[Length - 1, 0] = Chunks[11];
        }
    }      

    void InGameDisplay()
    {
        Vector3 pos = Vector3.zero;
        for (int i = 0; i < Length; i++)
        {            
            for (int j = 0; j < Width; j++)
            {
                Instantiate(map[i, j].chunk, new Vector3(i*-80, 0, j*-80), map[i,j].transform.rotation);                                                                             
            }
        }
    }
}

