using JsonReaderYugi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

//Clase que se encarga de mostrar las cartas disponibles para agregar al mazo en la escena "EditDeckScene"
public class RenderCards : MonoBehaviour
{
    public GameObject preFab;
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

        RenderAvailableCards();

    }

    //Busca el sprite pequeño (en baja resolución) de una carta dada su ID
    private Sprite GetSmallSprite(String id)
    {
        foreach(Sprite sprite in smallCardsSprites)
        {
            if (sprite.name.Equals(id))
                return sprite;
        }
        return null;
    }

    //Muestra las cartas disponibles para ser agregadas al mazo que se está editando
    private void RenderAvailableCards()
    {
        GameObject smallCardImage;

        foreach (Card c in cardList)
        {
            smallCardImage = (GameObject) Instantiate(preFab, transform);
            smallCardImage.GetComponent<Image>().sprite = GetSmallSprite(c.Id);
        }
    }

}
