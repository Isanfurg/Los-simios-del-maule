using JsonReaderYugi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderDeck : MonoBehaviour
{
    public GameObject preFab;
    static List<Card> cardList;
    static List<Sprite> bigCardsSprites;
    static List<Sprite> smallCardsSprites;
    void Start()
    {
        cardList = LoadData.cardList;
        bigCardsSprites = LoadData.bigCardsSprites;
        smallCardsSprites = LoadData.smallCardsSprites;

        RenderSelectedDeck();

        
        /*Deck deck = new Deck();
        Serializator.SerializeDeck(deck);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RenderSelectedDeck()
    {
        string path = "deck.dat";
        Deck deck = Serializator.DeserializeDeck(path);
        List<string> cardIds = deck.Cards;

        GameObject smallCardImage;
        foreach (string cardId in cardIds)
        {
            Debug.Log(cardId);
            smallCardImage = (GameObject)Instantiate(preFab, transform);
            smallCardImage.GetComponent<Image>().sprite = FindSmallCard(cardId);
        }
    }

    public Sprite FindSmallCard(string cardId)
    {
        for(int i = 0; i < smallCardsSprites.Count; i++)
        {
            Card card = cardList[i];
            
            if (cardId.Equals(card.Id))
            {
                
                return smallCardsSprites[i];
            }
        }

        return null;
    }
}
