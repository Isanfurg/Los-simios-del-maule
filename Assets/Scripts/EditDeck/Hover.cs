using JsonReaderYugi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Clase encargada de mostrar la carta en grande cuando se pasa el mouse por encima, en la escena "EditDeckScene"
public class Hover : MonoBehaviour, IPointerEnterHandler
{
    public Image bigImage;
    static List<Card> cardList;
    static List<Sprite> bigCardsSprites;
    static List<Sprite> smallCardsSprites;
    void Start()
    {   
        //Referencias a los datos cargados en memoria anteriormente
        LoadData instance = LoadData.GetInstance();
        cardList = instance.GetCardList();
        bigCardsSprites = instance.GetBigSprites();
        smallCardsSprites = instance.GetSmallSprites();
    }

    //Cuando el mouse entra a una carta, esta se muestra en la imagen "bigImage" que está en el centro de la escena
    public void OnPointerEnter(PointerEventData data)
    {
        bigImage.sprite = FindBigCardSprite(this.GetComponent<Image>().sprite.name);
    }

    //Busca el sprite grande del sprite pequeño de la carta (en más resolución)
    public Sprite FindBigCardSprite(string cardId)
    {
        foreach(Sprite card in bigCardsSprites)
        {
            if (cardId.Equals(card.name))
            {
                return card;
            }
        }
        return null;
    }
}
