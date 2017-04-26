using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChunkType { BLcorner, BRcorner, TLcorner, TRcorner, VPipe, HPipe, Cross, VLt, VRt, HLt, HRt, Bound } // { └, ┘, ┌, ┐, │, ─, ┼, ├, ┤, ┬, ┴, O}
public class Chunk : MonoBehaviour
{
    public ChunkType type;
    public Terrain chunk;
    public bool wallL;
    public bool WallR;
    public bool WallU;
    public bool WallD;
    public List<Terrain> neighboorsL;
    public List<Terrain> neighboorsR;
    public List<Terrain> neighboorsU;
    public List<Terrain> neighboorsD;
}