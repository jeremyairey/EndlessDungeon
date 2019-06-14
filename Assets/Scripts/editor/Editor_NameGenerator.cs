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

[CustomEditor(typeof(NameContainer), true)]
public class Editor_NameGenerator : EditorWindow
{
    int indexTotal;                     // How many total tiles do we have.
    int ActiveTile;
    public NameContainer TheNames;

    private Vector2 scrollPos = Vector2.zero;
    private Vector2 scrollPos2 = Vector2.zero;
    float currentScrollViewHeight;
    bool resize = false;
    Rect cursorChangeRect;


    [MenuItem("One Minute Dungeon/Name Editor")]

    public static void showWindow()
    {
        EditorWindow.GetWindow(typeof(Editor_NameGenerator));

    }

    void OnEnable()
    {
        hideFlags = HideFlags.HideAndDontSave;
        TheNames = NameContainer.Load(Path.Combine(Application.dataPath, "NameList.xml"));

        
        indexTotal = TheNames.PlayerNames.Count; 
        ActiveTile = indexTotal - 1;                // Set to the last made tile.

        this.position = new Rect(100, 100, 400, 700);
        currentScrollViewHeight = this.position.height;  //2
        cursorChangeRect = new Rect(0, currentScrollViewHeight, this.position.width, 5f);

    }



    void SaveData()
    {


        TheNames.Save(Path.Combine(Application.dataPath, "NameList.xml"));  //Saves in asset directory.
    }



}
