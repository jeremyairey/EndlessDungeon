using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingSnap : MonoBehaviour
{

    public RectTransform panel;  //To hold the scroll panel
    public Button[] bttn;
    public RectTransform center;  // Center to compare distance.
    

    private float[] distance;  // All buttons distance to center 
    private bool dragging = false;  // this will be true when we drag the panel
    private int bttnDistance;  //distance between buttons.
    private int minButtonNum; /// To hold number of button with smallest distance to center.

    //****************************************
    //****************************************
    private void Start()
    {
        int bttnLength = bttn.Length;
        distance = new float[bttnLength];

        //get distance between button 
        bttnDistance = (int)Mathf.Abs(bttn[1].GetComponent<RectTransform>().anchoredPosition.x - bttn[0].GetComponent<RectTransform>().anchoredPosition.x);

    }

    //****************************************
    //****************************************
    private void Update()
    {
        for (int i = 0; i < bttn.Length; i++)
        {
            distance[i] = Mathf.Abs(center.transform.position.x - bttn[i].transform.position.x);

            float minDistance = Mathf.Min(distance);   //get the min distance.

            for (int a = 0; a < bttn.Length; a++)
            {
                if (minDistance == distance[a])
                {
                    minButtonNum = a;
                }

            }

            if (!dragging)
            {
                LerpToBttn(minButtonNum * -bttnDistance);
            }
        }
    }

    //****************************************
    //****************************************
    void LerpToBttn(int position)
        {
      //  float newX = Mathf.Lerp(panel.anchoredPosition.x, position, Time.deltaTime * 10f);
     //   Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);
     //  panel.anchoredPosition = newPosition;

        }

    //****************************************
    //****************************************
    public void StartDrag()
    {
        dragging = true;

        Debug.Log("Dragging " + panel.anchoredPosition);
    }

    //****************************************
    //****************************************
    public void EndDrag()
    {
        dragging = false;
        Debug.Log("Stopp dragging!");

    }

}
