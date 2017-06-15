using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Map_Generator2 : NetworkBehaviour
{

    public List<Chunk> chunks;
    static public Chunk[,] map;
    static bool[,] hasPortal;  
    public Chunk bound;
    public GameObject spawner;
    public GameObject portal;
    public int Length;
    public int Width;
    public int rate;
    private bool once = true;

    void Start()
    {
        if (!isServer)
        {
            InGameDisplayClient();
            SetPortalClient();          
            return;
        }
        MapInit();
        Generator();
        InGameDisplay();
        SetPortal();
    }
    void Update()
    {
        if (!isServer)
            return;
        if ((PortalCount() == 0 && once) || Input.GetKeyDown(KeyCode.L))
        {
            var temp = (GameObject)Instantiate(portal, new Vector3(-40, 0, -40), new Quaternion());
            NetworkServer.Spawn(temp);
            once = false;
        }
    }

    void MapInit()
    {
        map = new Chunk[Length + 2, Width + 2];
        for (int j = 0; j < Width + 2; j++)
        {
            map[0, j] = bound;
            map[Length + 1, j] = bound;
        }
        for (int i = 0; i < Length + 2; i++)
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
                if (map[i, j].name == chunks[(int)ChunkType.Default].name)
                {
                    foreach (Chunk c in chunks)
                    {
                        if (c.neighboorsU.Contains(map[i - 1, j])
                            && c.neighboorsD.Contains(map[i + 1, j])
                            && c.neighboorsL.Contains(map[i, j - 1])
                            && c.neighboorsR.Contains(map[i, j + 1]))
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
        Debug.Log(".0");
        Vector3 pos = Vector3.zero;
        for (int i = 0; i < Length + 2; i++)
        {
            Debug.Log(".1");
            for (int j = 0; j < Width + 2; j++)
            {
                int rdm = Random.Range(0, map[i,j].chunksVariants.Count);
                var temp = (GameObject)Instantiate(map[i,j].chunksVariants[rdm], new Vector3(i * -80, 0, j * -80), map[i, j].transform.rotation);
                NetworkServer.Spawn(temp);
            }
        }                    
    }

    void InGameDisplayClient()
    {
        Vector3 pos = Vector3.zero;
        for (int i = 0; i < Length + 2; i++)
        {
            Debug.Log("..1");
            for (int j = 0; j < Width + 2; j++)
            {
                Debug.Log("i,j:" + i + " " + j +" | "+ map[i, j]);
                Debug.Log("..2");                
                int rdm = Random.Range(0, map[i, j].chunksVariants.Count);
                Debug.Log("..3");
                Instantiate(map[i, j].chunksVariants[rdm], new Vector3(i * -80, 0, j * -80), map[i, j].transform.rotation);
                Debug.Log("..4");
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

    void SetPortal()
    {
        hasPortal = new bool[Length, Width];
        for (int i = 0; i < Length; i++)
            for (int j = 0; j < Width; j++)
                hasPortal[i, j] = false;
        Quaternion rotation = Quaternion.Euler(120, 0, 0);     
        int curr_rate = 0;        
        while (curr_rate < rate)
            for (int i = 0; i < Length; i++)
            {                
                for (int j = 0; j < Width; j++)
                {
                    if (Random.Range(0, 99) == 4 && curr_rate < rate && !hasPortal[i, j])
                    {                        
                        var temp = (GameObject)Instantiate(spawner, new Vector3(i * -80, 1, j - 80 - 40), rotation);
                        NetworkServer.Spawn(temp);
                        Debug.Log("Portal placed at:" + i + ", " + j);
                        curr_rate += 1;
                        hasPortal[i, j] = true;
                    }
                }
            }
    }

    void SetPortalClient()
    {
        Quaternion rotation = Quaternion.Euler(120, 0, 0);
        for (int i = 0; i < Length; i++)        
            for (int j = 0; j < Width; j++)            
                if (hasPortal[i, j])
                    Instantiate(spawner, new Vector3(i * -80, 1, j - 80 - 40), rotation);                    
    }
    int PortalCount()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Enemy");
        int rate = Length * Width / 10 + 1;
        int curr_rate = 0;
        for (int i = 0; i < temp.Length; i++)
        {
            if (temp[i].name == "Portal(Clone)")
                curr_rate += 1;
        }
        return curr_rate;
    }

    /*void SetMapSaved()
    {
        int ligne = map.GetLength(0);
        int colonne = map.GetLength(1);
        string n;

        for (int i = 0; i < ligne; i++)
        {
            for (int j = 0; j < colonne; j++)
            {
                n = PlayerPrefs.GetString("[" + i + "," + j + "]");
                switch (n)
                {
                    case "0(Clone)":
                        map[i,j] = bound;
                        break;
                }
            }
        }
    }*/
}
