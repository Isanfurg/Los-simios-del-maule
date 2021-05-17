using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler{
    private GameObject cardIn;


    void Start()
    {
        cardIn = null;
    }
    public void OnDrop(PointerEventData eventData){
        Debug.Log("Card dropped");
        DragDropCard card = eventData.pointerDrag.GetComponent<DragDropCard>();

        if(card != null && cardIn == null){
            
            card.returnPoint = this.transform;
            cardIn = card.gameObject;
            //Destroy(card.gameObject.GetComponent<DragDropCard>());
        }


    }


}
