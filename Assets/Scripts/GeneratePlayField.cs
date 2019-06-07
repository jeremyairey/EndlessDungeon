using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GeneratePlayField : MonoBehaviour
{
    
public GameObject[] Tiles;
    public enum TileLocked { Locked, Open};

    public GameObject parentRef;
    public GameObject tilePrefab;  //Playfield tile.

       

    public List<GameObject> tileObjects = new List<GameObject>();


    public int Columns=3;  // How many across
    public int Rows = 3;   // How many down

    public float playfieldWidth;
    public float playfieldHeight;

    public float posX = -105; //x
    public float posY = 200;   //y
    public int stepX=105;
    public int stepY = -105;

    public int spacer = 10;
    


    // Start is called before the first frame update
    void Start()
    {
        //-105,200
        //105,-105

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


        Debug.Log("button size X " + buttonSizeX);
        Debug.Log("button size Y " + buttonSizeY);



        //Tile1: -105,200
        //Tile2: 0,200
        //Tile3: 105,200
        //Tile4: -105,95
        //Tile5: 0,95
        //Tile6: 105,95
        //Tile7: -105,-10
        //Tile8: 0,-10
        //Tile9: 105,-10
        int count = 0;

        for(int i=0; i< Rows; i++)
        {
            
            for(int j=0; j< Columns; j++)
            {

                count++;
    
                GameObject g = (GameObject)Instantiate(tilePrefab, transform.position, Quaternion.identity);

                g.transform.SetParent(parentRef.transform); //false?
                g.transform.localPosition = new Vector2(currentX, currentY);
                g.transform.localScale=parentRef.transform.localScale;
                g.gameObject.name = "Tile_" + count;


                tileObjects.Add(g);

        

                //Debug.Log(parentRef.transform.localScale);
                //Debug.Log("Tile [ " + count + "]  X:" + currentX + " Y:" + currentY );
                currentX += stepX;
                
            }
            currentX = posX;
            currentY += stepY;
        }

        SpawnTile(1);
        SpawnTile(9);

    }


    private void SpawnTile(int whichtile)
    {

        whichtile--;   //To adjust for the 1-9 display we want

        //tileObjects[whichtile].GetComponent<Button>.colors
        //WIP


        tileObjects[whichtile].gameObject.name = "done";
        


        /*

        GameObject g = (GameObject)Instantiate(tilePrefab, transform.position, Quaternion.identity);
        g.transform.SetParent(parentRef.transform); //false?
        g.transform.localPosition = new Vector2(currentX, currentY);
        g.transform.localScale = parentRef.transform.localScale;
        g.gameObject.name = "Tile_" + count;

    */



    }


    // Update is called once per frame
    void Update()
    {
    }
}
