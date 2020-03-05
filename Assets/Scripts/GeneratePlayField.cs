using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class GeneratePlayField : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    public TileContainer ButtonTiles;
    
    public GameObject[] Tiles;
    public enum TileLocked { Locked, Open};

    public GameObject parentRef;
    public GameObject tilePrefab;  //Playfield tile.

    public List<GameObject> tileObjects = new List<GameObject>();

    public int Columns=3;  // How many across
    public int Rows = 3;   // How many down

    float playfieldWidth;   // Width of playfield where we draw the buttons
    float playfieldHeight;  // Height of playfield where we draw the buttons
    float posX = 0;       //Starting position of tile in X   
    float posY = 0;       //Starting position of tiel in Y
    float stepX = 0;      //
    float stepY = 0;    

    public int spacer = 10;


    // Start is called before the first frame update
    void Start()
    {
        


        float adjWidth;
        float adjHeight;
        float currentX = posX;
        float currentY = posY;

        playfieldWidth = parentRef.GetComponent<RectTransform>().sizeDelta.x;   // get size of panel width  --> 310
        playfieldHeight = parentRef.GetComponent<RectTransform>().sizeDelta.y;  // get size of panel height --> 300
        adjWidth = playfieldWidth - (spacer * Rows);       // how much width we have to work with for each button   220
        adjHeight = playfieldHeight - (spacer * Columns);  // how much height we have to work with for each button  210

        float buttonSizeX = adjWidth / Columns;
        float buttonSizeY = adjHeight / Rows;


        //Debug.Log("button size X " + buttonSizeX);
        //Debug.Log("button size Y " + buttonSizeY);
        //Debug.Log("adj Width " + tilePrefab.GetComponent<RectTransform>().rect.width);
        //Debug.Log("adj Height " + tilePrefab.GetComponent<RectTransform>().rect.height);
        //Debug.Log("current X " + currentX);
        //Debug.Log("current Y " + currentY);

                        
        int count = 0;
               
        stepX = buttonSizeX+spacer;
        stepY = buttonSizeY+spacer;


        for (int i=0; i< Rows; i++)
        {
            
            for(int j=0; j< Columns; j++)
            {

                count++;
    

                GameObject g = (GameObject)Instantiate(tilePrefab, transform.position, Quaternion.identity);

                g.transform.SetParent(parentRef.transform); //false?
                g.transform.localPosition = new Vector2(currentX, currentY);
                g.transform.localScale = new Vector3(buttonSizeX / tilePrefab.GetComponent<RectTransform>().rect.width, buttonSizeY / tilePrefab.GetComponent<RectTransform>().rect.height, parentRef.transform.localScale.z);
                g.gameObject.name = "Tile_" + count;
                //g.gameObject.AddComponent<ItemSlot>();  //make it so we can drag and drop this as a receptacle.
                //g.gameObject.AddComponent<DragDrop>();  //make it so we can drag and drop this as an object.
                g.gameObject.GetComponent<DragDrop>().SetCanvas(canvas);
                                       

                tileObjects.Add(g);
                //Debug.Log(parentRef.transform.localScale);
                //Debug.Log("Tile [ " + count + "]  X:" + currentX + " Y:" + currentY );
                currentX += stepX;
            }
            currentX = posX;
            currentY -= stepY;
        }

        SetRarity();
               
    }


    void SetRarity()
    {

        for(int i=0; i<=(Columns*Rows); i++)
        {
            //Debug.Log("# " + (Columns * Rows) + " of " + i + " rarity: " + ButtonTiles.Tiles[i].rare_type);

          //  Debug.Log(ButtonTiles.Tiles.Count);


            if (i <= ButtonTiles.Tiles.Count-1 &&  ButtonTiles.Tiles[i].rare_type == Global.RarityTypes.Legendary)
            {
                tileObjects[i].GetComponent<Image>().color = new Color32(255, 165, 0, 255);
                DecorateTile(i);
            }
        }
                     
    }


    private void SpawnTile(int whichtile)
    {

        whichtile--;   //To adjust for the 1-9 display we want

        //tileObjects[whichtile].GetComponent<Button>.colors
        //WIP

        //tileObjects[whichtile].gameObject.name = "done";
        tileObjects[whichtile].GetComponent<Image>().color = new Color32(255, 165, 0, 255);

        /*

        GameObject g = (GameObject)Instantiate(tilePrefab, transform.position, Quaternion.identity);
        g.transform.SetParent(parentRef.transform); //false?
        g.transform.localPosition = new Vector2(currentX, currentY);
        g.transform.localScale = parentRef.transform.localScale;
        g.gameObject.name = "Tile_" + count;

    */



    }


    //************************************************
    //*****
    //************************************************
    
    public float  DecorateTile( int tileindex)
    {

        //tileObjects[tileindex].gameObject.name = ButtonTiles.Tiles[tileindex].Name;
        

        tileObjects[tileindex].GetComponentInChildren<Text>().text= ButtonTiles.Tiles[tileindex].Name;

        //Debug.Log(ButtonTiles.Tiles[tileindex].Name);


        //  TileRecord[index].TileName = ThisTile.Tiles[gameTile._tileID].Name;
        //  TileRecord[index].Rarity = ThisTile.Tiles[gameTile._tileID].rare_type;
        //  TileRecord[index].DescriptionEntry = ThisTile.Tiles[gameTile._tileID].DescriptionEntry;
        //  TileRecord[index].DescriptionWaiting = ThisTile.Tiles[gameTile._tileID].DescriptionWaiting;
        //  TileRecord[index].DescriptionFinal = ThisTile.Tiles[gameTile._tileID].DescriptionFinal;
        //  TileRecord[index].SetMyTexture = Resources.Load(Global.TileTexturePath + ThisTile.Tiles[gameTile._tileID].TileImage) as Texture;


        return (1);
    }


    // Update is called once per frame
    void Update()
    {
    }


    private void Awake()
    {
        ButtonTiles = TileContainer.Load(Path.Combine(Application.dataPath, "Tiles.xml"));
    }

}
