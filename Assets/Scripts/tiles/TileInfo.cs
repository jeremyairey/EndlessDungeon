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
    //private Texture _tileImage;
    public Vector3 theobject;
    private string _themeName;
    private int _ID;            //Index number for


    private string _descriptionEntry;
    private string _descriptionWaiting;
    private string _descriptionFinal;





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
        _rarity = Global.RarityTypes.None;
        _tileName = "Default tileName";
        _descriptionEntry = "Default Entry Description";
        _descriptionWaiting = "Default Waiting Description";
        _descriptionFinal = "Default Final Description";

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
        Debug.Log("DESC: " + DescriptionEntry);

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

        _rarity = Global.RarityTypes.None;
        _tileName = "Default tileName";

        _descriptionEntry = "Default Entry Description";
        _descriptionWaiting = "Default Waiting Description";
        _descriptionFinal = "Default Final Description";

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

    public Texture SetMyIcon
    {
        get { return _icon; }
        set { _icon = value; }
    }


    /*
    public Texture TileImage
    {
        get { return _tileImage; }
        set { _tileImage = value; }
    }

    */

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

        }

             
    }



}//end of class TileInfo

