using System.Xml;
using System.Xml.Serialization;


public class PlayerName 
{
    [XmlAttribute("name")]

    public string Honorific;
    public string FirstName;
    public string LastName;
    public string HouseName;
             
}
