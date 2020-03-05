using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;


public class ItemSlot : MonoBehaviour, IDropHandler
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
}
