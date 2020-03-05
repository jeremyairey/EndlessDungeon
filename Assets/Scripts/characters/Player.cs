using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using System;

/*
 * 
   PLAYER CHARACTER
     first name
     last name
     location (home land)
     Portrait


    Class
    Race
    Gender
    Gold
    Experience
    Inventory


    Attributes
        Strength
        Int
        Wisdom
        Charisma
        Dexterity
        Luck


    DUNGEON
    3x4 grid

    Quest Generation
    --> Quest is built from QUEST LIBRARY
      -->  Slay, Steal, or Save -each of these has their own quests


    TILE PACKS (Dice Packs)
    At start, only basic location and monster types available
    --> packs purchased with in game gold
    --> packs purchased / earned by completing (X) dungeons or specific challenges or high level mobs.

    Tiles (DICE) have 3 classes (rarity)  - standard, rare, epic.
    Each tile has a glyph corresponding to a ROOM type

    ROOM/ LOCATION
      Room, Crypt, Tower, Cave, Shrine, Gulag, Dead End



          



     * 
     * * * */



public class Player : MonoBehaviour
{

    private bool isMale = false;  //If is male, then you are male, if not you are female.

    private string _firstname;
    private string _lastname;
    private string _location;
    private int _level;
    private uint _freeExp;
    

    private Attribute[] _primaryAttribute;
    //private Vital[] _vital;
    //private Skill[] _skill;


       
    
    //Holds all the data strings for the characters and their locations

    public string[] FirstNamesMale;
    public string[] FirstNamesFemale;
    public string[] LastNames;
    public string[] LocationNames;

    //public int playerNameIndex[]


    private void Awake()
    {
        _firstname = string.Empty;
        _lastname = string.Empty;
        _location = string.Empty;
        _level = 0;
        _freeExp = 0;

    }

    //************************
    //************************
    void Start()
    {
                LoadNameLists();
               
    }


    //************************
    //************************
    void LoadNameLists()
    {
        FirstNamesMale = System.IO.File.ReadAllLines(Path.Combine(Application.dataPath, "FirstNamesMale.txt"));
        FirstNamesFemale = System.IO.File.ReadAllLines(Path.Combine(Application.dataPath, "FirstNamesFemale.txt"));
        LastNames = System.IO.File.ReadAllLines(Path.Combine(Application.dataPath, "LastNames.txt"));
        LocationNames = System.IO.File.ReadAllLines(Path.Combine(Application.dataPath, "LocationNames.txt"));

    }

    //************************
    //************************
    // Update is called once per frame
    void Update()
    {
        
    }
}
