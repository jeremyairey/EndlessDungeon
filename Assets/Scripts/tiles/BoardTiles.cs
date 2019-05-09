using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

using rds;

public class BoardTiles : MonoBehaviour
{

    public TileInfo[] TileRecord;                   //Array of classes references to Tile Objects
    public TileContainer ThisTile;                   //for the xml list of classes
  //  public Themes _Themes;                          //Themes reference
    public float[] RarityTable = new float[24];     //Holds our rarity tables for the tiles

    public GameObject prefab;               //Base tile to use - set intside the Inspector
    Vector3 theobject;                      //gameobject position for tiles (location) 
    int drawstartposition;                  // where tiles start generating on the right WIP Change to viewport culling perhaps? 288
    public int num_tiles;                   //Total tiles to draw in front and back of the player position
    public int tilesSpawned = 0;                //So we know how many tiles we've made before theme can change
    public TextAsset xmlTileData;



    void Awake()
    {
        num_tiles = Global.BoardTilesToGenerate;
        TileRecord = new TileInfo[num_tiles];
        

        

        for (int x = 0; x < num_tiles; x++)
        {
            TileRecord[x] = new TileInfo();
        }

        //DEVICE LOADING ONLY
        //ThisTile = TileContainer.LoadiPhoneText("xmlTile");   //This one works.

        //DEVELOPMENT LOADING
        	ThisTile=TileContainer.Load(Path.Combine(Application.dataPath, "Tiles.xml"));		


        //Create Master Tables	

        //Prpbability is here
        // Sum of ALL probabilities in the table, a random value is picked then it loops through the contents and looks for the first value that is larger than the random
        Global.TileTableRarity.AddEntry(Global.TileTableRarityCommon, 20);
        Global.TileTableRarity.AddEntry(Global.TileTableRarityUnCommon, 3);
        Global.TileTableRarity.AddEntry(Global.TileTableRarityRare, 2);
        Global.TileTableRarity.AddEntry(Global.TileTableRarityEpic, 2);
        Global.TileTableRarity.AddEntry(Global.TileTableRarityLegendary, 1);
        Global.TileTableRarity.AddEntry(Global.TileTableRarityGodly, 1);
        Global.TileTableRarity.AddEntry(Global.TileTableRarityTrap, 2);
        Global.TileTableRarity.AddEntry(Global.TileTableRarityEncounter, 20);
        //Debug.Log (rds.RDSRandom.GetDoubleValue(32768));

    }

    void Start()
    {
        //	_Themes=GameObject.Find ("CarrotTile").GetComponent<Themes>();					//Theme reference

        //JWA for building unity file.		
        // ThisTile = TileContainer.Load(Path.Combine(Application.dataPath, "Tiles.xml"));	//Load our data


        ParseXMLtoTables();                                                              // Process the XML and read it into a table.
       //JWA 2 PopulateBoard();                                                                //Generate new tile board
    }

    //Process the XML data into the Rarity Tables - stores the tileID and the probability.
    void ParseXMLtoTables()
    {

        for (int i = 0; i < ThisTile.Tiles.Count; i++)
        {

            switch (ThisTile.Tiles[i].rare_type)
            {

                case Global.RarityTypes.Godly:
                    Global.TileTableRarityGodly.AddEntry(new RarityTables(ThisTile.Tiles[i].ID), ThisTile.Tiles[i].Probability);
                    break;

                case Global.RarityTypes.Legendary:
                    Global.TileTableRarityLegendary.AddEntry(new RarityTables(ThisTile.Tiles[i].ID), ThisTile.Tiles[i].Probability);
                    break;

                case Global.RarityTypes.Epic:
                    Global.TileTableRarityEpic.AddEntry(new RarityTables(ThisTile.Tiles[i].ID), ThisTile.Tiles[i].Probability);
                    break;

                case Global.RarityTypes.Rare:
                   Global.TileTableRarityRare.AddEntry(new RarityTables(ThisTile.Tiles[i].ID), ThisTile.Tiles[i].Probability);
                    break;


                case Global.RarityTypes.Common:
                    Global.TileTableRarityCommon.AddEntry(new RarityTables(ThisTile.Tiles[i].ID), ThisTile.Tiles[i].Probability);
                    break;

                case Global.RarityTypes.UnCommon:
                    Global.TileTableRarityUnCommon.AddEntry(new RarityTables(ThisTile.Tiles[i].ID), ThisTile.Tiles[i].Probability);
                    break;

                case Global.RarityTypes.Trap:
                    Global.TileTableRarityTrap.AddEntry(new RarityTables(ThisTile.Tiles[i].ID), ThisTile.Tiles[i].Probability);
                    break;

                //case Global.RarityTypes.Encounter:
                  //  Global.TileTableRarityEncounter.AddEntry(new RarityTables(ThisTile.Tiles[i].ID), ThisTile.Tiles[i].Probability);
//                    break;
                                       

                default:

                    break;
            }



        }



    }


    //This generates the board for the first RUN.	
    public void PopulateBoard()
    {
        if (Global.firstrun == true) { drawstartposition = -(1 * Global.BoardTileSize_x); }     //-(1*Global.BoardTileSize_x)



        for (int x = 0; x < num_tiles; x++)
        {
            theobject = new Vector3(drawstartposition + (x * Global.BoardTileSize_x), 0, 0);                  //change from minus to PLUS

            //Generate the RAW physical tile object and add the movement componenet to it.	
            TileRecord[x].BoardTile = Instantiate(prefab, theobject, Quaternion.identity) as GameObject;
//            TileRecord[x].BoardTile.AddComponent("TileMoveManager");    //Used to move tiles on the boat
            
            TileRecord[x].BoardTile.name = "tile" + x;
            TileRecord[x].BoardTile.transform.localScale = new Vector3(Global.BoardTileSize_x, Global.BoardTileSize_y, Global.BoardTileSize_z);

            DecorateTile(x);

            if (x >= 6) { Global.firstrun = false; } // Number of tiles behind the player.
            if (Global.firstrun == true)
            {


                TileRecord[x].CleanTileRecord();
                TileRecord[x].Rarity=Global.RarityTypes.None;
                TileRecord[x].SetMyTexture = Resources.Load(Global.TileTexturePath + "BLANK") as Texture;
                TileRecord[x].SetMyBorderTexture = Resources.Load(Global.TileTexturePath + "BLANK") as Texture;

            } //First few tiles should always be blank

            //rendere obsolte JWA 
            //TileRecord[x].BoardTile.renderer.materials[1].mainTexture = TileRecord[x].SetMyTexture;
            //TileRecord[x].BoardTile.renderer.materials[0].mainTexture = TileRecord[x].SetMyBorderTexture;


        }
    }

    //Generates a new Tile.
    public void Generate_Single_Tile(int index)
    {
        float holder_x = 0;
        int x = 99;

        x = index;

        if (index == 0)
        {
            holder_x = Global.roundUp((int)TileRecord[num_tiles - 1].BoardTile.transform.position.x, 64);

            holder_x = holder_x + Global.BoardTileSize_x;
            theobject = new Vector3(holder_x, 0, 0);    //-96,215
        }
        else
        {
            theobject = new Vector3(Global.roundUp((int)TileRecord[index - 1].BoardTile.transform.position.x + Global.BoardTileSize_x, 64), 0, 0);
            //Debug.Log ("index:" + (index-1) +  "pos:" + theobject + "trgt:" + target);
        }

        TileRecord[x].BoardTile.transform.position = theobject;
        DecorateTile(x);


        //TileRecord[x].BoardTile.renderer.materials[1].mainTexture = TileRecord[x].SetMyTexture;  //Set Main Textuyre
        //TileRecord[x].BoardTile.renderer.materials[0].mainTexture = TileRecord[x].SetMyBorderTexture;

        tilesSpawned++;


        //THEME SHIT HERE
        if (tilesSpawned >= 20) //how often to change theme
        {
            //	_Themes.PickTheme();
            tilesSpawned = 0;
        }


        //## GENERATE A SPECIAL BACKDROP CARROT?


    }

    //This populates our board tile with all relevant information
    public float DecorateTile(int index)
    {

        // roll does not matter, just need to know the tileIndex - and the board tile index.
        //Let's ROLL our tile out of the table.  	


        //JWA2
        return (1);
                
        

        var gameTile = (RarityTables)Global.TileTableRarity.rdsResult.First();

        //Set our theme - not really used right now.
        //	TileRecord[index].Theme=_Themes.ActiveTheme.ToString();

        //All tiles have these fields	
        TileRecord[index].TileName = ThisTile.Tiles[gameTile._tileID].Name;
        TileRecord[index].Rarity = ThisTile.Tiles[gameTile._tileID].rare_type;
        TileRecord[index].DescriptionEntry = ThisTile.Tiles[gameTile._tileID].DescriptionEntry;
        TileRecord[index].DescriptionWaiting = ThisTile.Tiles[gameTile._tileID].DescriptionWaiting;
        TileRecord[index].DescriptionFinal = ThisTile.Tiles[gameTile._tileID].DescriptionFinal;



        TileRecord[index].SetMyTexture = Resources.Load(Global.TileTexturePath + ThisTile.Tiles[gameTile._tileID].TileImage) as Texture;
        
        
        //Not using anything here yet.  Possibly check some unity properties and action against them.
        switch (ThisTile.Tiles[gameTile._tileID].rare_type)
        {

            case Global.RarityTypes.Godly:

                break;

            case Global.RarityTypes.Legendary:

                break;

            case Global.RarityTypes.Epic:

                break;


            case Global.RarityTypes.Rare:

                break;

            case Global.RarityTypes.UnCommon:

                break;

            case Global.RarityTypes.Common:

                break;

            case Global.RarityTypes.Trap:

                break;


            case Global.RarityTypes.None:

                break;

                            
            default:
                Debug.Log("Could not find item rank");
                break;

        }

        return (99);

    }


}//end of class BoardTiles

//  materials[1] (access to the shaders in order)  1=the main texture, 0 = the rim.
//	TileRecord[x].BoardTile.renderer.materials[1].mainTexture=GenericTiles[(int)Global.RarityTypes.Common];	
