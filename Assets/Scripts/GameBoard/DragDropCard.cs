using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Clase para arrastar las cartas de los jugadores
public class DragDropCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Transform returnPoint;

    //Cuando empieza el arrastrado
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("Start dragging");
        returnPoint = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    //Mientras se est� arrastrando
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("On dragging");
        this.transform.position = eventData.position;
        
    }

    //Cuando se termina el arrastrado
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("End dragging");
        this.transform.SetParent(returnPoint);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
