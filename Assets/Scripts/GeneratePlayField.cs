using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GeneratePlayField : MonoBehaviour
{
    public GameObject[] Tiles;
    public enum TileTypes { Blank, Cave, Crypt, DeadEnd,Gulag, Room, Shrine, Tower};
    public enum TileLocked { Locked, Open};
    public enum Shit { };


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
