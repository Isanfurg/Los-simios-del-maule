using JsonReaderYugi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler{
    private GameObject cardIn;
    public string zoneType;


    void Start()
    {
        cardIn = null;
    }
    public void OnDrop(PointerEventData eventData){
        Debug.Log("Card dropped");
        DragDropCard card = eventData.pointerDrag.GetComponent<DragDropCard>();

        if(card != null && cardIn == null){
            //Verifica que la carta sea un monstruo
            GameObject cardDropped = card.gameObject;
            Sprite cardSprite = cardDropped.GetComponent<Image>().sprite;
            string cardID = cardSprite.name;
            Card cardInfo = SearchCard(cardID);
            string cardType = cardInfo.Type;

            if(!cardType.Equals("Trap Card") && !cardType.Equals("Spell Card"))
            {
                card.returnPoint = this.transform;
                cardIn = cardDropped;
            }
                
            
            //Destroy(card.gameObject.GetComponent<DragDropCard>());
        }


    }

    private Card SearchCard(string id)
    {
        LoadData data = LoadData.GetInstance();
        List<Card> cards = data.GetCardList();

        foreach(Card card in cards)
        {
            if (id.Equals(card.Id))
                return card;
        }

        return null;
    }

}
