using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler
{
    [SerializeField] private Canvas canvas;

    public static GameObject itemBeingDragged;  //When I click and object, this is the one I will drag and move
    public static GameObject itemToReceive;     //This will be the item I will drop.
    
    Vector3 startPosition;
    Transform startParent;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

      
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
     }

    public void SetCanvas( Canvas whichCanvas)
    {
        canvas = whichCanvas;
    }

  
    public void OnPointerDown(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;    //We know this will be our source object to be dragged.
        eventData.useDragThreshold = false;

        //Debug.Log("(PressedRayCast): " + eventData.pointerPressRaycast.gameObject.transform.parent.name);
        

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;

        //itemBeingDragged = gameObject;    //We know this will be our source object to be dragged.
        startPosition = transform.position;
        startParent = transform.parent;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        itemBeingDragged = null;  //Does this clear first or does OnDrop trigger first?
        canvasGroup.alpha = 1.0f;
        //transform.position = startPosition;

        canvasGroup.blocksRaycasts = true;

        if(transform.parent == startParent)
        {
             transform.position = startPosition;
        }



    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
     }


    public void OnPointerEnter(PointerEventData eventData)
    {
        itemToReceive = eventData.pointerCurrentRaycast.gameObject;
        //Debug.Log(" Receive: " + itemToReceive.transform.parent.name);

        //Debug.Log(" Receive: " + eventData.pointerCurrentRaycast.gameObject.name);
        
    }
}
