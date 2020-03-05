using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute : MonoBehaviour
{

    [SerializeField] string AttributeName;
    [SerializeField] int currentValue;
    [SerializeField] int baseValue;
    //[SerializeField] Icon icon;   //list of icons
            


    public string Name
    {
        get { return AttributeName;  }
        set { AttributeName = value; }

    }

    public int BaseValue
    {
        get { return baseValue;  }
        set { baseValue = value; }
     }

    public int CurrentValue
    {
        get { return currentValue; }
        set { currentValue = value; }

    }


    //https://www.youtube.com/watch?v=2EH41YYqU5o&list=PL_eGgISVYZkdXANkfLtY878xRx19ZqyQz&index=3
    //burgzerger




}
