using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


[System.Serializable]
public class TileInfo
{
    private string _tileName;               //Name listed under tile
    private Global.RarityTypes _rarity;
    private int _ID;                         //Index number for

    private string _descriptionEntry;       //What it says when you first walk into a room.....then...
    private string _descriptionWaiting;     //Now time is ticking, you should do something because...
    private string _descriptionFinal;       //Shit just went down.





    
    void Start()
    {
        _rarity = Global.RarityTypes.Common;
        _tileName = "MyName";
        _ID = 0;
    //    theobject = new Vector3(10, 10, 10);
    }


    public TileInfo()
    {
        _rarity = Global.RarityTypes.None;
        _tileName = "Default tileName";
        _descriptionEntry = "Default Entry Description";
        _descriptionWaiting = "Default Waiting Description";
        _descriptionFinal = "Default Final Description";

        _ID = 0;
      

    }


    public TileInfo(int index, string name, Global.RarityTypes rare)
    {
        _rarity = rare;
        _tileName = name;
        _ID = index;
    }


    public void ReportTile()
    {

        
        Debug.Log("NAME: " + TileName);
        Debug.Log("DESC: " + DescriptionEntry);

        

    }


    
    public void CleanTileRecord()
    {

        _rarity = Global.RarityTypes.None;
        _tileName = "Default tileName";

        _descriptionEntry = "Default Entry Description";
        _descriptionWaiting = "Default Waiting Description";
        _descriptionFinal = "Default Final Description";

        _ID = 0;
      
    }



    //Name listed under tile
    public string Name
    {
        get { return _tileName; }
        set { _tileName = value; }
    }


    public string DescriptionEntry
    {
        get { return _descriptionEntry; }
        set { _descriptionEntry = value; }
    }

    public string DescriptionWaiting
    {
        get { return _descriptionWaiting; }
        set { _descriptionWaiting = value; }
    }


    public string DescriptionFinal
    {
        get { return _descriptionFinal; }
        set { _descriptionFinal = value; }
    }



    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }

    //public Texture SetMyIcon
    //{
        //get { return _icon; }
        //set { _icon = value; }
    //}


    
    
    public Global.RarityTypes Rarity
    {
        get { return _rarity; }
        set { _rarity = value; }
    }

    public string TileName
    {
        get { return _tileName; }
        set { _tileName = value; }
    }

    
    /*
    //Currently not being used.
    //Find out what TRAP we landed on and adjust the game accordingly.
    public void TileTrap(Global.TrapTypes trap, int index, TileInfo[] TileRecord, Texture[] GenericTexture)
    {

        TileRecord[index].Rarity = Global.RarityTypes.Trap;  //The rarity is of type TRAP.

        switch (trap)
        {

            case Global.TrapTypes.None:
                break;

        }

             
    }

    */


}//end of class TileInfo

