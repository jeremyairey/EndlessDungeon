using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

[XmlRoot("NameCollection")]
public class NameContainer
{
    [XmlArray("PlayerNames")]
    [XmlArrayItem("Name")]
    public List<PlayerName> PlayerNames = new List<PlayerName>();


    //Save file
    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(NameContainer));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }


    //Loading Local and for EDITOR
    public static NameContainer Load(string path)
    {
        
        var serializer = new XmlSerializer(typeof(NameContainer));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as NameContainer;
        }

    }

    //FOR iPhone loading
    public static NameContainer LoadiPhone(TextAsset xmlAsset)
    {
               
        var serializer = new XmlSerializer(typeof(NameContainer));
        MemoryStream stream = new MemoryStream(xmlAsset.bytes);
        return serializer.Deserialize(stream) as NameContainer;

    }




    public static NameContainer LoadiPhoneText(string path)
    {
        var serializer = new XmlSerializer(typeof(NameContainer));


        TextAsset textAsset = (TextAsset)Resources.Load("xmlData/" + path, typeof(TextAsset));
        if (textAsset == null) { Debug.Log("Could not load: " + path); }
        return serializer.Deserialize(new StringReader(textAsset.ToString())) as NameContainer;
    }



    //Loads the xml directly from the given string. Useful in combination with www.text.
    public static NameContainer LoadFromText(string text)
    {
        var serializer = new XmlSerializer(typeof(NameContainer));
        return serializer.Deserialize(new StringReader(text)) as NameContainer;
    }

         

}