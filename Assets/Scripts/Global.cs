using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.Xml;
using System.Linq;
using System.Text;

using rds;

public static class Global
{


        //public static SpellContainer SpellBook;


    // public static GameObject[] positionArray = new GameObject[ActionButtonDiceSlots + 1];  //Dice Slots in Actionbar
     
    //public static TPAtlas myAtlas;          //Atlas for ICONS
    
    // Paths
    public static string TileTexturePath = "tiles/textures/";
       
    

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


   
    //TRAPS
    public enum TrapTypes
    {
        None,
        Robbed,
        Quicksand
    }

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

    public enum ChallengeType
    {
        None,
        Combat,
        Trap,
        Puzzle,
        Conversation

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

 
