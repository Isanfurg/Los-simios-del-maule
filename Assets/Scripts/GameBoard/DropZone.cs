using JsonReaderYugi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Clase que detecta cuando una carta se suelta en la zona de monstruos
public class DropZone : MonoBehaviour, IDropHandler{
    private GameObject cardIn;
    public string zoneType;


    void Start()
    {
        cardIn = null;
    }

    //Cuando se suelta la carta, la zona de monstruos intersectada pasa a albergar esa carta
    public void attack()
    {
        
        PlayerLife.playerLifeNow -= 400;
        Image LifeP1 = GameObject.Find("LifeP1").GetComponent<Image>();
        LifeP1.fillAmount = PlayerLife.playerLifeNow / PlayerLife.playerLife;
    }

    public void OnDrop(PointerEventData eventData){
        //Debug.Log("Card dropped");
        DragDropCard card = eventData.pointerDrag.GetComponent<DragDropCard>();

        if(card != null && cardIn == null){
            //Verifica que la carta sea un monstruo
            GameObject cardDropped = card.gameObject;
            
            if(this.gameObject.transform.parent.gameObject.name.Equals("EnemyMat"))
            {
                attack();
            }
            Sprite cardSprite = cardDropped.GetComponent<Image>().sprite;
            string cardID = cardSprite.name;
            Card cardInfo = SearchCard(cardID);
            string cardType = cardInfo.Type;

            if(!cardType.Equals("Trap Card") && !cardType.Equals("Spell Card"))
            {
                card.returnPoint = this.transform;
                cardIn = cardDropped;
            }
            else
            {
                attack();
            }
            //Destroy(card.gameObject.GetComponent<DragDropCard>());
        }
    }

    //Busca los datos de una carta dada su id
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
