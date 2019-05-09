using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;



[ExecuteInEditMode]


[CustomEditor(typeof(TileContainer), true)]
public class TilePacks : EditorWindow
{
    int indexTotal;         // How many total tiles do we have.
    int TileCount = 0;   //What tile number are we on.
    int ActiveTile = 0;   //What tile are we currently operating on.

    public Texture tempobject;
    public TileContainer ThisTile;
    public Vector2 scrollPosition;
    public GameObject tempGameOject;


    private Vector2 scrollPos = Vector2.zero;
    private Vector2 scrollPos2 = Vector2.zero;
    float currentScrollViewHeight;
    bool resize = false;
    Rect cursorChangeRect;




    [MenuItem("One Minute Dungeon/Tile Editor")]
    public static void showWindow()
    {
        EditorWindow.GetWindow(typeof(TilePacks));

    }

    void OnEnable()
    {
        hideFlags = HideFlags.HideAndDontSave;
        ThisTile = TileContainer.Load(Path.Combine(Application.dataPath, "Tiles.xml"));

        indexTotal = ThisTile.Tiles.Count;      // How mamy elements we have.
        ActiveTile = indexTotal - 1;                // Set to the last made tile.


        this.position = new Rect(100, 100, 400, 700);
        currentScrollViewHeight = this.position.height;  //2
        cursorChangeRect = new Rect(0, currentScrollViewHeight, this.position.width, 5f);

    }


    
    void OnGUI()
    {

        indexTotal = ThisTile.Tiles.Count;

        GUILayout.BeginHorizontal(GUILayout.MaxWidth(200));
        GUILayout.Space(5);

        //Create a new tile
        if (GUILayout.Button("NEW TILE", EditorStyles.miniButtonMid, GUILayout.MaxWidth(200)))
        {
            indexTotal++;                               //Add to our max tile count.
            ThisTile.Tiles.Add(new TileData());     //Generate a new tile instance.	
            MakeNewTileEntry(indexTotal - 1);

        }
                
        //Remove Tile
        if (GUILayout.Button("DELETE TILE", EditorStyles.miniButtonMid, GUILayout.MaxWidth(200)))
        {

            int killme = ActiveTile;

            ActiveTile--;

            ThisTile.Tiles.Remove(ThisTile.Tiles[killme]);
            indexTotal--;

            for (int i = 0; i < ThisTile.Tiles.Count; ++i)
            {
                ThisTile.Tiles[i].ID = i;
            }

        }


        //Create a new tile
        if (GUILayout.Button("RESET ID's", EditorStyles.miniButtonMid, GUILayout.MaxWidth(200)))
        {
            for (int i = 0; i < ThisTile.Tiles.Count; ++i)
            {
                ThisTile.Tiles[i].ID = i;
            }

        }
               
        GUILayout.EndHorizontal();

        //***************

        GUILayout.BeginHorizontal(GUILayout.MaxWidth(200));
        GUILayout.Space(5);
        DrawToolStrip();
        GUILayout.EndHorizontal();

        //**************
        ShowTileData();

    }

    void DrawToolStrip()
    {
        //PREVIOUS TILE
        if (GUILayout.Button("<=-", EditorStyles.miniButtonMid))
        {
            TileCount--;
            if (TileCount <= 0) { TileCount = 0; }  //Make sure we don't leave
            ActiveTile = TileCount;           //Set our active tile

        }

        //SAVE TILES
        if (GUILayout.Button("Save to XML", EditorStyles.miniButtonMid))
        {
            SaveData();
            //	EditorGUIUtility.ExitGUI();
        }

        //NEXT TILE
        if (GUILayout.Button("-=>", EditorStyles.miniButtonMid))
        {
            TileCount++;
            if (TileCount >= indexTotal) { TileCount = indexTotal - 1; }
            ActiveTile = TileCount;                 //Set out active tile
        }

    }

    void MakeNewTileEntry(int index)
    {
        ThisTile.Tiles[index].ID = index;
        ThisTile.Tiles[index].Name = "TILE NAME";
     }



    void ShowTileData()
    {

        //scrollPosition=EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.Width(600), GUILayout.Height(800));

        GUILayout.BeginVertical();

        scrollPos = GUILayout.BeginScrollView(scrollPos, GUILayout.Height(currentScrollViewHeight));


        //Total Tiles
        EditorGUILayout.LabelField("");
        EditorGUILayout.LabelField("Total Tiles: " + ThisTile.Tiles.Count, EditorStyles.boldLabel);
        EditorGUILayout.LabelField("");

        //ID
        EditorGUILayout.LabelField("ID", ThisTile.Tiles[ActiveTile].ID.ToString());

        //NAME	
        ThisTile.Tiles[ActiveTile].Name = EditorGUILayout.TextField("Name", ThisTile.Tiles[ActiveTile].Name);

        //RARITY TYPE
        ThisTile.Tiles[ActiveTile].rare_type = (Global.RarityTypes)EditorGUILayout.EnumPopup("RARITY", ThisTile.Tiles[ActiveTile].rare_type);

        //TILE TYPE
        ThisTile.Tiles[ActiveTile].tile_type = (Global.TileTypes)EditorGUILayout.EnumPopup("TILES", ThisTile.Tiles[ActiveTile].tile_type);


        //Probability
        ThisTile.Tiles[ActiveTile].Probability = EditorGUILayout.FloatField("Probability:", ThisTile.Tiles[ActiveTile].Probability, GUILayout.MaxWidth(200));


        // Description Entry
        ThisTile.Tiles[ActiveTile].DescriptionEntry = EditorGUILayout.TextField("Entry Text", ThisTile.Tiles[ActiveTile].DescriptionEntry);

        // Description Waiting
        ThisTile.Tiles[ActiveTile].DescriptionWaiting = EditorGUILayout.TextField("Waiting Text", ThisTile.Tiles[ActiveTile].DescriptionWaiting);

        // Description Final
        ThisTile.Tiles[ActiveTile].DescriptionFinal = EditorGUILayout.TextField("Final Text", ThisTile.Tiles[ActiveTile].DescriptionFinal);

        // Commentary
        ThisTile.Tiles[ActiveTile].Commentary = EditorGUILayout.TextField("Commentary", ThisTile.Tiles[ActiveTile].Commentary);


        //hasWard
        ThisTile.Tiles[ActiveTile].hasWard = (bool)EditorGUILayout.Toggle("Has Ward", ThisTile.Tiles[ActiveTile].hasWard);

        //hasLock
        ThisTile.Tiles[ActiveTile].hasLock = (bool)EditorGUILayout.Toggle("Has Lock", ThisTile.Tiles[ActiveTile].hasLock);

        //hasKeyReward
        ThisTile.Tiles[ActiveTile].hasKeyReward = (bool)EditorGUILayout.Toggle("Key Reward", ThisTile.Tiles[ActiveTile].hasKeyReward);

        //hasSpellReward
        ThisTile.Tiles[ActiveTile].hasSpellReward = (bool)EditorGUILayout.Toggle("Spell Reward", ThisTile.Tiles[ActiveTile].hasSpellReward);


         
        //Tile Image  JWA may need to fix
         ThisTile.Tiles[ActiveTile].TileImage= EditorGUILayout.TextField("my text",ThisTile.Tiles[ActiveTile].TileImage);



        //Dungeon entry?
        ThisTile.Tiles[ActiveTile].isDungeon = (bool)EditorGUILayout.Toggle("DungeonActivator", ThisTile.Tiles[ActiveTile].isDungeon);


        // Stat 1
        ThisTile.Tiles[ActiveTile].stat1 = EditorGUILayout.IntField("Stat1:", ThisTile.Tiles[ActiveTile].stat1, GUILayout.MaxWidth(200));

        //Special1	
        ThisTile.Tiles[ActiveTile].special1 = EditorGUILayout.IntField("Spec1:", ThisTile.Tiles[ActiveTile].special1, GUILayout.MaxWidth(200));
        //Special2	
        ThisTile.Tiles[ActiveTile].special2 = EditorGUILayout.IntField("Spec2:", ThisTile.Tiles[ActiveTile].special2, GUILayout.MaxWidth(200));





        GUILayout.EndScrollView();  //JWA
         
        //GUILayout.FlexibleSpace();

        //GUILayout.BeginVertical();
        //     scrollPos2 = GUILayout.BeginScrollView(scrollPos2,GUILayout.Height(currentScrollViewHeight));	

 /*       

        //Main Tile Texture
        tempobject = (Texture)EditorGUILayout.ObjectField("", tempobject, typeof(Texture), false);
        EditorGUILayout.LabelField("Tile Face: ", ThisTile.Tiles[ActiveTile].TileImage);

        if (tempobject == null) { }
        else
        {
            ThisTile.Tiles[ActiveTile].TileImage = tempobject.name;
            tempobject = null;
        }


//OMD STAY?
        //EditorGUILayout.EndToggleGroup();


        EditorGUILayout.LabelField("");

        
   
        //CENTER PIECE PROP	
        EditorGUILayout.LabelField("");


        EditorGUILayout.EndToggleGroup();

        EditorGUILayout.LabelField("");


        
        EditorGUILayout.EndScrollView();	

        //GUILayout.FlexibleSpace();
        EditorGUILayout.LabelField("");
        EditorGUILayout.LabelField("");

        //GUILayout.EndVertical();

        //GUILayout.EndScrollView();  //JWA	


 */       
        Repaint();

    }



    void SaveData()
    {

        ThisTile.Save(Path.Combine(Application.dataPath, "Tiles.xml"));  //Saves in asset directory.
    }



    public void OnInspectorUpdate()
    {
        Repaint();
    }




    void TileDataLoad()
    {

        //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(TileData));
        //     return xmlSerializer.Deserialize(new StringReader(xmlFile.text)) as TileData;
    }


    private void ResizeScrollView()
    {
        GUI.DrawTexture(cursorChangeRect, EditorGUIUtility.whiteTexture);
        EditorGUIUtility.AddCursorRect(cursorChangeRect, MouseCursor.ResizeVertical);
        
        if (Event.current.type == EventType.MouseDown && cursorChangeRect.Contains(Event.current.mousePosition))
        {
            resize = true;
        }
        if (resize)
        {
            currentScrollViewHeight = Event.current.mousePosition.y;
            cursorChangeRect.Set(cursorChangeRect.x, currentScrollViewHeight, cursorChangeRect.width, cursorChangeRect.height);
        }
        if (Event.current.type == EventType.MouseUp)
            resize = false;
    }



    void SetFoldoutColor(int clrIdx)
    {
        float r = 0f;
        float g = 0f;
        float b = 0f;
        Color newColorA;
        Color newColorB;

        float[,] colorVals =
        {
            {180,   180,    180},	//NO_TYPE	255	51	68
			{66,    225,    27},	//WEAPON		
			{28,    137,    240},	//SHIELD
			{187,   28,     234},	//CHARM
			{234,   94,     28},	//ARMOR
			{255,   223,    111},	//GLOVES
			{255,   51,     68},	//BOOTS
		};

        if (clrIdx == 0)//default
        {
            newColorA = new Color(0.706f, 0.706f, 0.706f, 1.0f);
            newColorB = new Color(1.0f, 0.2f, 0.267f, 1.0f);
        }
        else
        {
            r = (float)(colorVals[clrIdx, 0] / 255f);
            g = (float)(colorVals[clrIdx, 1] / 255f);
            b = (float)(colorVals[clrIdx, 2] / 255f);
            newColorA = new Color(r, g, b, 1.0f);
            newColorB = new Color(r, g, b, 1.0f);
        }

        EditorStyles.foldout.normal.textColor = newColorA;
        EditorStyles.foldout.onNormal.textColor = newColorB;
        EditorStyles.foldout.hover.textColor = newColorB;
        EditorStyles.foldout.onHover.textColor = newColorB;
        EditorStyles.foldout.focused.textColor = newColorB;
        EditorStyles.foldout.onFocused.textColor = newColorB;
        EditorStyles.foldout.active.textColor = newColorB;
        EditorStyles.foldout.onActive.textColor = newColorB;

    }


}

