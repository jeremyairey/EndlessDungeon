using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;
// using UnityEditor;

[XmlRoot("TileCollection")]
public class TileContainer
{
    [XmlArray("Tiles"), XmlArrayItem("TileData")]
    public List<TileData> Tiles = new List<TileData>();


    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(TileContainer));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }


    //Loading Local and for EDITOR
    public static TileContainer Load(string path)
    {


        var serializer = new XmlSerializer(typeof(TileContainer));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as TileContainer;
        }

    }

    //FOR iPhone loading
    public static TileContainer LoadiPhone(TextAsset xmlAsset)
    {



        var serializer = new XmlSerializer(typeof(TileContainer));
        MemoryStream stream = new MemoryStream(xmlAsset.bytes);
        return serializer.Deserialize(stream) as TileContainer;

    }




    public static TileContainer LoadiPhoneText(string path)
    {
        var serializer = new XmlSerializer(typeof(TileContainer));


        TextAsset textAsset = (TextAsset)Resources.Load("xmlData/" + path, typeof(TextAsset));
        if (textAsset == null) { Debug.Log("Could not load: " + path); }
        return serializer.Deserialize(new StringReader(textAsset.ToString())) as TileContainer;
    }



    //Loads the xml directly from the given string. Useful in combination with www.text.
    public static TileContainer LoadFromText(string text)
    {
        var serializer = new XmlSerializer(typeof(TileContainer));
        return serializer.Deserialize(new StringReader(text)) as TileContainer;
    }




    public void GenerateNew()
    {
        Tiles.Add(new TileData());

    }


}