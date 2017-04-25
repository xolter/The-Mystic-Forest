using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Type { BLcorner, BRcorner, TLcorner, TRcorner, VPipe, HPipe, Cross, VLt, VRt, HLt, HRt, Bound } // { └, ┘, ┌, ┐, │, ─, ┼, ├, ┤, ┬, ┴}
public class Chunk : MonoBehaviour
{
    Type type;
    public Terrain chunk;
    public List<Terrain> neighboorsL;
    public List<Terrain> neighboorsR;
    public List<Terrain> neighboorsU;
    public List<Terrain> neighboorsD;
}