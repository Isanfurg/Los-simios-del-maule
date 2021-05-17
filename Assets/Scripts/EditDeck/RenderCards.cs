using JsonReaderYugi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class RenderCards : MonoBehaviour
{
    public GameObject preFab;
    static List<Card> cardList;
    static List<Sprite> bigCardsSprites;
    static List<Sprite> smallCardsSprites;
    void Start()
    {
        LoadData instance = LoadData.GetInstance();
        cardList = instance.GetCardList();
        bigCardsSprites = instance.GetBigSprites();
        smallCardsSprites = instance.GetSmallSprites();



        RenderAvailableCards();



        /*String path = "CardsID.txt";
        CardsLoader cLoader = new CardsLoader();
        cLoader.StartDownload(path);
        String pathC = "cards.dat";
        cards = Serializator.DeserializeCards(pathC);
        List<JsonReaderYugi.Card> ListOfCards = cards.cardList;
        foreach (JsonReaderYugi.Card card in ListOfCards)
        {
            card.ToString();
        }*/

        




    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Sprite GetSmallSprite(String id)
    {
        foreach(Sprite sprite in smallCardsSprites)
        {
            if (sprite.name.Equals(id))
                return sprite;
        }
        return null;
    }

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
