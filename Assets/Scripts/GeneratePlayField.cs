﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GeneratePlayField : MonoBehaviour
{
    
public GameObject[] Tiles;
    public enum TileLocked { Locked, Open};

    public GameObject parentRef;
    public GameObject tilePrefab;  //Playfield tile.

    //public int playLocations = new int[3, 3];
    public int[,] Grid;

    public int Columns=3;  // How many across
    public int Rows = 3;   // How many down

    public float posX = -105; //x
    public float posY = 200;   //y
    public int stepX=105;
    public int stepY = -105;



    // Start is called before the first frame update
    void Start()
    {
       Grid = new int[Columns, Rows];
        

        float currentX = posX;
        float currentY = posY;

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

        for(int i=0; i< Columns; i++)
        {
            
            for(int j=0; j< Rows; j++)
            {

                count++;
                GameObject g = (GameObject)Instantiate(tilePrefab, transform.position, Quaternion.identity);

                g.transform.SetParent(parentRef.transform); //false?
                g.transform.localPosition = new Vector2(currentX, currentY);
                g.transform.localScale=parentRef.transform.localScale;
                g.gameObject.name = "Tile_" + count;

                Debug.Log(parentRef.transform.localScale);
                Debug.Log("Tile [ " + count + "]  X:" + currentX + " Y:" + currentY );
                currentX += stepX;
                
            }
            currentX = posX;
            currentY += stepY;
        }
     
    }


    private void SpawnTile(int whichTile)
    {

        


        
        
    }


    // Update is called once per frame
    void Update()
    {
    }
}
