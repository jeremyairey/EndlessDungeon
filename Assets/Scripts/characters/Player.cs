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
    // Start is called before the first frame update
    void Start()
    {
        string[] FirstNames = System.IO.File.ReadAllLines(Path.Combine(Application.dataPath, "FirstNames.txt"));
        string[] LastNames = System.IO.File.ReadAllLines(Path.Combine(Application.dataPath, "LastNames.txt"));
        string[] LocationNames = System.IO.File.ReadAllLines(Path.Combine(Application.dataPath, "LocationNames.txt"));


        Debug.Log("NAME IS: " + FirstNames[1]);
        Debug.Log("NAME IS: " + FirstNames[2]);
        Debug.Log("NAME IS: " + FirstNames[3]);
        Debug.Log("NAME IS: " + FirstNames[4]);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
