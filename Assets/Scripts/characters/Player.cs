using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

public class Player : MonoBehaviour
{
    // Start is called before the f

    public string[] FirstNamesMale;
    public string[] FirstNamesFemale;
    public string[] LastNames;
    public string[] LocationNames;

    //************************
    //************************
    void Start()
    {
                LoadNameLists();
               
    }

    //************************
    //************************
    void LoadNameLists()
    {
        FirstNamesMale = System.IO.File.ReadAllLines(Path.Combine(Application.dataPath, "FirstNamesMale.txt"));
        FirstNamesFemale = System.IO.File.ReadAllLines(Path.Combine(Application.dataPath, "FirstNamesFemale.txt"));
        LastNames = System.IO.File.ReadAllLines(Path.Combine(Application.dataPath, "LastNames.txt"));
        LocationNames = System.IO.File.ReadAllLines(Path.Combine(Application.dataPath, "LocationNames.txt"));

    }

    //************************
    //************************
    // Update is called once per frame
    void Update()
    {
        
    }
}
