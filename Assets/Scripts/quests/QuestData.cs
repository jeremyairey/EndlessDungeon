using System.Xml;
using System.Xml.Serialization;

using UnityEngine;

public class QuestData
{

    //TYPE:  Slay,Steal, Save

    [XmlAttribute("name")]
    public string Name;                                                   //Name of the quest
    public Global.RarityTypes rare_types = Global.RarityTypes.Common;     //How rare is this quest?
    public Global.QuestType quest_type = Global.QuestType.None;           //What type of quest is it?   
    public int ID;                                                        //ID for this quest
    public bool Unique;                                                   //Is this a one off quest?
    public int Probability;                                               //chance of this quest happening?
    public float DynamicProbability;                                      //Can this be influeneced by anything else?
    public string Description;                                            //What this quest objective is.
    public string Commentary;                                             //what happens when you encounter the quest, what does the quest text say?
    public string Image;                                                  //Is there an image associated to this quest?
    public int GoalTile;                                                  //Holds the TILE (GLYPH) ID.
}

