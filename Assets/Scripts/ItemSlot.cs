using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler
{

    public GameObject dragitem
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;

        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("SOURCE: " + DragDrop.itemBeingDragged.name);
        //Debug.Log("DEST: " + gameObject.name);

     
        if(DragDrop.itemBeingDragged.name != gameObject.name)
        {

            
            DragDrop.itemBeingDragged.transform.SetParent(transform);

            DragDrop.itemBeingDragged.transform.localPosition = Vector3.zero;
            

            ///transform.GetChild(0).gameObject.GetComponent<RectTransform>().localPosition = Vector3.zero;

            Debug.Log("Merged 2 tiles: " + gameObject.name);
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //itemToReceive = eventData.pointerCurrentRaycast.gameObject;


        //Color myColor = new Color(Random.Range(30, 255), Random.Range(30, 255), Random.Range(30, 255), 255);
        int r = Random.Range(0, 255);
        int g = Random.Range(0, 255);
        int b = Random.Range(0, 255);

        //Color32 myColor = new Color32((byte)r, (byte)g, (byte)b, 255);
        Color32 myColor = new Color32((byte)Random.Range(30, 255), (byte)Random.Range(30, 255), (byte)Random.Range(30, 255), 255);


        //this.gameObject.transform.Find("imgShadow").GetComponent<Image>().color = myColor;

        
        this.gameObject.GetComponentsInChildren<Image>()[0].color = myColor;

        //Debug.Log(" My Color: " + myColor + " on tile: " + this.gameObject.transform.name);



    }
}
