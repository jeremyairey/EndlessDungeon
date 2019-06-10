using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.Xml;
using System.Linq;
using System.Text;

using rds;

public static class Global
{

    //public static int ActionButtonDiceSlots = 12; // Lets exclude (0) from this.



    //public static GameObject TargetEnemy = null;
    //public static SpellContainer SpellBook;


    // public static GameObject[] positionArray = new GameObject[ActionButtonDiceSlots + 1];  //Dice Slots in Actionbar
     
    //public static TPAtlas myAtlas;          //Atlas for ICONS
    //public static TPAtlas myHudIcons;

    // Paths
    public static string TileTexturePath = "tiles/textures/";



    //This will set the position, rotation and scale of the 'enhance tile'
    //public static Vector3 TileHighlightPosition = new Vector3(114, 22, 0);
    //public static Vector3 TileHighlightRotation = new Vector3(0, 348, 0);
    //public static Vector3 TileHighlightScale = new Vector3(192, 10, 192);
    //public static int TileLastIndex = 99;
    //public static bool TileZoomed = false;
    //Player character position on zoomed tile
    //public static Vector3 CharHighlightPosition = new Vector3(125, 22, -70);
    //public static Vector3 CharHighlightRotation = new Vector3(0, 0, 0);
    //public static Vector3 CharHighlightScale = new Vector3(2, 2, 2);


    //The various Rarity tables and subtables
    public static rds.RDSTable rdsRarityProbability = new rds.RDSTable();
    public static rds.RDSTable TileTableRarity = new rds.RDSTable();
    public static rds.RDSTable TileTableRarityCommon = new rds.RDSTable();
    public static rds.RDSTable TileTableRarityUnCommon = new rds.RDSTable();
    public static rds.RDSTable TileTableRarityRare = new rds.RDSTable();
    public static rds.RDSTable TileTableRarityEpic = new rds.RDSTable();
    public static rds.RDSTable TileTableRarityLegendary = new rds.RDSTable();
    public static rds.RDSTable TileTableRarityGodly = new rds.RDSTable();
    public static rds.RDSTable TileTableRarityTrap = new rds.RDSTable();
    public static rds.RDSTable TileTableRarityEncounter = new rds.RDSTable();


    //  Global Variables	

    //public static bool characterMoving = false;
    //public static bool firstrun = true;         //is this the very first time we've run the 'game'  Draws blank tiles underneath player.
    //public static bool rolling = false;         //Is the dice actively rolling about.
    //public static bool first_roll_ever = true;  //Is this the first time we've ever rolled the dice.
    //public static bool detectTile = false;      //Is it time to detect what tile we are standing own.
    //public static int standingOnTileIndex = 99; // Default value to check if we'
    //public static int BoardTilesToGenerate = 32;  //How many tiles do we generate?   --THIS IS CURRENTLY PASSED TO A VARIABLE.
    //public static int BoardTileSize_x = 64;
    //public static int BoardTileSize_y = 10;
    //public static int BoardTileSize_z = 64;


    //Combat information
    //public static bool inCombat = false;
    //public static bool inVictoryPhase = false;
    //public static int numberOfEnemies = 1;



    //public static int DIR_UP = 1;           //Zooming in on a tile or opening something
    //public static int DIR_DOWN = 0;     //Zooming back to normal or closing something


    //public static float tilespeed = 1.0f; // how many seconds to move.
    //public static int lastRoll;         //Last dice value we rolled

    //Converts a string number to an int number.
    public static int StringToInt(string instring)
    {
        int result = 99;
        int.TryParse(instring, out result);
        return result;

    }


    // THis will round-up to a multiple of whatever we pass to it.
    public static int roundUp(int numToRound, int multiple)
    {
        if (numToRound < 0) multiple = -multiple;

        return (numToRound + multiple / 2) / multiple * multiple;
    }

    public enum AtlasTouse
    {
        myAtlas = -2,
        myHudIcons = -1
    }

 

    //Theme Types
    public enum ThemeTypes
    {
        None,
        Transition,
        Air,
        Earth,
        Fire,
        Ice,
        Jungle,
        Water

    }

    //TRAPS
    public enum TrapTypes
    {
        None,
        Robbed,
        Quicksand
    }

    // May move these to a player class.
    //Race Types
    public enum RaceTypes
    {
        None,
        Human,
        Elf,
        Goblin,
        Orc

    }

    //Sex Types
    public enum SexType
    {
        None,
        Male,
        Female
    }

    //CLASSES
    public enum ClassType
    {
        None,
        Warrior,
        Mage,
        Hunter,
        Druid,
        Rogue,
        Bard
    }

    public enum StatTypes
    {
        None,
        Strength,
        IQ,
        Wisdom,
        Dexterity,
        Constitution,
        Charisma
    }

    
    //Quest Types
    public enum QuestType
    {
        None,
        Slay,
        Steal,
        Save
    }

    //******************************************
    //TILE INFO
    //******************************************

    //Rarity Types
    public enum RarityTypes
    {
        None,
        Common,
        UnCommon,
        Rare,
        Epic,
        Legendary,
        Godly,
        Trap
    }

    //If a tile is opened or locked by a glyph or a ward.
    public enum TileAccess
    {
        Open,
        Ward,
        Glyph
    }


    public enum TileTypes {
        Blank,
        Cave,
        Crypt,
        DeadEnd,
        Gulag,
        Room,
        Shrine,
        Tower
    }

    public enum TileAccessRewards
    {
        None,
        Ward,
        Lock,
        Both
    }


	
public static int GetTileId(rds.RDSTable theTable, int hitResults)
	{
	
		theTable.rdsCount=hitResults;
			
		foreach (RarityTables resultTrap in theTable.rdsResult)	 
		{ 
		
		
		  return resultTrap._tileID;
			
			
		//	Debug.Log(string.Format ("    {0}", resultTrap._tileID));
		}		
		
		return(-99);
		
		
	}
	

}//End of Class


/*
 * 
 * 
 <?xml version ="1.0"?>
<TileCollection xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Tiles>
    <TileData name=""Godly 1">
      <rare_type>Common</rare_type>
      <tile_type>Cave</tile_type>
      <ID>0</ID>
      <isDungeon>false</isDungeon>
      <Probability>1</Probability>
      <DescriptionEntry>Entry Desc</DescriptionEntry>
      <DescriptionWaiting>I'm waiting</DescriptionWaiting>
      <DescriptionFinal>Final Desc</DescriptionFinal>
      <Commentary>this is commentary</Commentary>
      <stat1>1</stat1>
      <special1>1</special1>
      <special2>2</special2>
                    
    </TileData>
    
  </Tiles>
</TileCollection>
*/

 
