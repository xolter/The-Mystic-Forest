using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChunkType { BLcorner, BRcorner, TLcorner, TRcorner, VPipe, HPipe, Cross, VLt, VRt, HLt, HRt, Default, Fix1, Bound } // { └, ┘, ┌, ┐, │, ─, ┼, ├, ┤, ┬, ┴, 0, ┼-2, |-2, ─-2, O}
public class Chunk : MonoBehaviour
{
    public ChunkType type;
    public List<Terrain> chunksVariants;
    //public Terrain chunk;
    public List<Chunk> neighboorsL;
    public List<Chunk> neighboorsR;
    public List<Chunk> neighboorsU;
    public List<Chunk> neighboorsD;
}