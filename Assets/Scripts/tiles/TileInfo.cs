using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


[System.Serializable]
public class TileInfo
{
    private string _tileName;
    private Global.RarityTypes _rarity;
    private GameObject _boardTile;
    private Texture _tileTexture;
    private Texture _borderTexture;
    public Vector3 theobject;
    private string _themeName;
    private int _ID;            //Index number for
    private string _description;
    private Texture _icon;
    private Texture _groundTexture;
    private Texture _groundTextureBorder;
    private bool _zoomTrigger;
    private bool _carrotTrigger;

    private string _pathMasterProp;
    private string _pathCenterProp;
    private string _pathRandomProps;

    void Start()
    {
        _rarity = Global.RarityTypes.Common;
        _tileName = "MyName";
        _ID = 0;
        theobject = new Vector3(10, 10, 10);
    }


    public TileInfo()
    {
        _rarity = Global.RarityTypes.Plain;
        _tileName = "Default tileName";
        _description = "Default Description";
        _ID = 0;
        theobject = new Vector3(10, 10, 10);
        _zoomTrigger = false;
        _carrotTrigger = false;

        _pathRandomProps = "need props";

    }


    public TileInfo(int index, string name, Global.RarityTypes rare)
    {
        _rarity = rare;
        _tileName = name;
        _ID = index;
    }


    public void ReportTile()
    {

        //	GUI.Label(new Rect(10, 10, 100, 20)," HATPIHSDIINDINW");

        Debug.Log("NAME: " + TileName);
        Debug.Log("DESC: " + Description);

        //Debug.Log("MASTER: " + MasterPropPath);
        //Debug.Log("Center: " + CenterPropPath);
        //Debug.Log("Zoom: " + ZoomTrigger);
        //Debug.Log ("SPECIAL: " + SetMyGroundTexture);


    }


    public void TriggerBlend(GameObject myObj, Texture myTexture)
    {
        //CrossFade tempObj;
        //myObj.GetComponent<Renderer>().material.shader = Shader.Find("CrossFade");
        //tempObj = GameObject.Find(myObj.name).GetComponent<CrossFade>();
        //tempObj.CrossFadeTo(myTexture);


    }


    public void CleanTileRecord()
    {

        _rarity = Global.RarityTypes.Plain;
        _tileName = "Default tileName";
        _description = "Default Description";
        _ID = 0;
        theobject = new Vector3(10, 10, 10);
        _zoomTrigger = false;
        _carrotTrigger = false;

        _pathRandomProps = "need props";
    }


    //Link to the master prop object		
    public string MasterPropPath
    {
        get { return _pathMasterProp; }
        set { _pathMasterProp = value; }
    }

    //Path to the center prop object	
    public string CenterPropPath
    {
        get { return _pathCenterProp; }
        set { _pathCenterProp = value; }
    }

    //Path for the random props.	
    public string RandomPropPath
    {
        get { return _pathRandomProps; }
        set { _pathRandomProps = value; }
    }


    //Shoudl be zoom the tile in or not.
    public bool ZoomTrigger
    {
        get { return _zoomTrigger; }
        set { _zoomTrigger = value; }
    }


    //Does this spawn a special backdrop?
    public bool CarrotTrigger
    {
        get { return _carrotTrigger; }
        set { _carrotTrigger = value; }
    }


    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }


    public int ID
    {
        get { return _ID; }
        set { _ID = value; }
    }

    public Texture SetMyIcon
    {
        get { return _icon; }
        set { _icon = value; }
    }

    //Used for the default tile face
    public Texture SetMyTexture
    {
        get { return _tileTexture; }
        set { _tileTexture = value; }
    }

    //Used for the default border face
    public Texture SetMyBorderTexture
    {
        get { return _borderTexture; }
        set { _borderTexture = value; }
    }


    public Texture SetMyGroundTexture
    {
        get { return _groundTexture; }
        set { _groundTexture = value; }
    }

    public Texture SetMyGroundTextureBorder
    {
        get { return _groundTextureBorder; }
        set { _groundTextureBorder = value; }
    }


    public GameObject BoardTile
    {
        get { return _boardTile; }
        set { _boardTile = value; }
    }


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

    public string Theme
    {
        get { return _themeName; }
        set { _themeName = value; }
    }

    //Currently not being used.
    //Find out what TRAP we landed on and adjust the game accordingly.
    public void TileTrap(Global.TrapTypes trap, int index, TileInfo[] TileRecord, Texture[] GenericTexture)
    {

        TileRecord[index].Rarity = Global.RarityTypes.Trap;  //The rarity is of type TRAP.

        switch (trap)
        {

            case Global.TrapTypes.None:
                break;

            case Global.TrapTypes.Robbed:
                TileRecord[index].SetMyTexture = GenericTexture[(int)Global.RarityTypes.Trap];      //Apply our texture
                TileRecord[index].TileName = "ROBBED:  Oh No, you've been Robbed";                          //Set info about the tile!
                TileRecord[index].Description = "Some Bandits came along and stole yer booty!"; //Color description.
                break;

            case Global.TrapTypes.Quicksand:
                TileRecord[index].SetMyTexture = GenericTexture[8];
                TileRecord[index].TileName = "QUICKSAND:  Your movement has been slowed";
                TileRecord[index].Description = "You feel bogged down!";
                break;
        }

    }



}//end of class TileInfo

