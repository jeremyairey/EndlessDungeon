using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
//using rds;


public class TileData
{
        //  keys and spells are inventory items and can unlock or ward break any respective spell / lock
        //When we generate a lock tile or ward tile, we must put a potion or key in another location AND....
        //....that location cannot be a warded room or locked room or boss room.

    [XmlAttribute("name")]
    public int ID;                                                      //Tile ID
    public string Name;                                                 //Name of Tile
    public Global.RarityTypes rare_type = Global.RarityTypes.Standard;  //Default to standard rarity
    public Global.TileTypes tile_type = Global.TileTypes.Blank;         //Default is a blank tile
    public float Probability;                                           //Chance for this type of tile room to spawn.
    public string DescriptionEntry;                                     //What it says when you first walk into a room.... THEN...
    public string DescriptionWaiting;                                   //Now time is ticking and you should do something because...
    public string DescriptionFinal;                                     //....shit just went down.
    public string Commentary;                                           //Some color commentary about this type of tile
    public bool hasWard = false;                                        //Is this room locked with a ward.
    public bool hasLock = false;                                        //Is this room locked with a lock.
    public bool hasKeyReward = false;                                   //Did we spawn a key?
    public bool hasSpellReward = false;                                 //Did we spawn a spell?
           
}
