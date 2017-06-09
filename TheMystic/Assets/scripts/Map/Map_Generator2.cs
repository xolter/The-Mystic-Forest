using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Generator2 : MonoBehaviour {

    public List<Chunk> chunks;
    public Chunk[,] map;
    public Chunk bound;
    public int Length;
    public int Width;

    void Start()
    {
        MapInit();
        Generator();
        InGameDisplay();
        ConsoleDisplay();
    }

    void MapInit()
    {
        map = new Chunk[Length+2, Width+2];
        for (int j = 0; j < Width + 2; j++)
        {
            map[0, j] = bound;
            map[Length + 1, j] = bound;
        } 
        for(int i =0; i < Length +2; i++)
        {
            map[i, 0] = bound;
            map[i, Width + 1] = bound;
        }
        for (int i = 1; i < Length + 1; i++)
            for (int j = 1; j < Width + 1; j++)
            {
                map[i, j] = chunks[(int)ChunkType.Default];                
            }
    }

    void Generator()
    {
        List<Chunk> possible = new List<Chunk>();
        map[1, 1] = chunks[(int)ChunkType.TLcorner];
        //map[1, Width] = chunks[(int)ChunkType.TRcorner];
        map[Length, 1] = chunks[(int)ChunkType.BLcorner];
        map[Length, Width] = chunks[(int)ChunkType.BRcorner];
        for (int i = 1; i < Length + 1; i++)
        {            
            possible = new List<Chunk>();
            for (int j = 1; j < Width + 1; j++)
            {                
                possible = new List<Chunk>();                
                if (map[i, j].chunk.name == chunks[(int)ChunkType.Default].name)
                {                    
                    foreach (Chunk c in chunks)
                    {
                        if (c.neighboorsU.Contains(map[i - 1, j].chunk)
                            && c.neighboorsD.Contains(map[i + 1, j].chunk)
                            && c.neighboorsL.Contains(map[i, j - 1].chunk)
                            && c.neighboorsR.Contains(map[i, j + 1].chunk))
                        {
                            possible.Add(c);                            
                        }

                    }
                    if (possible.Count > 0)
                        map[i, j] = possible[Random.Range(0, possible.Count - 1)];
                    else
                        map[i, j] = chunks[(int)ChunkType.Default];
                }
            }
        }
    }

    void InGameDisplay()
    {
        Vector3 pos = Vector3.zero;
        for (int i = 0; i < Length+2; i++)
        {
            for (int j = 0; j < Width+2; j++)
            {
                Instantiate(map[i, j].chunk, new Vector3(i * -80, 0, j * -80), map[i, j].transform.rotation);
            }
        }
    }

    void ConsoleDisplay()
    {
        string str = "";
        for (int i = 0; i < Length + 2; i++)
        {
            for (int j = 0; j < Width + 2; j++)
                str += map[i, j].name;
            str += "\n";
        }
        Debug.Log(str);
    }
}
