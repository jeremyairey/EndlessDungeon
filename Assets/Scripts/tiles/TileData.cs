using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
//using rds;


public class TileData
{
        
    [XmlAttribute("name")]
    public string Name;
    public Global.RarityTypes rare_type = Global.RarityTypes.Plain;
    public Global.TrapTypes trap_type = Global.TrapTypes.None;
    public int ID;
    public bool Unique;
    public bool isDungeon;
    public int Probability;
    public float DynamicProbability;
    public string Description;
    public string Commentary;
    public int stat1;
    public int stat2;
    public int stat3;
    public int special1;
    public int special2;
    public int special3;
    public int special4;
    public int special5;
    public int LastBoardIndex;
    public string TileImage;
    
}
