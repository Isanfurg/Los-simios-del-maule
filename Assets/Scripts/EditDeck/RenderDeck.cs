using JsonReaderYugi;
using System;
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
    public static Deck deck;
    public static int init = 0;
    void Start()
    {
        cardList = LoadData.cardList;
        bigCardsSprites = LoadData.bigCardsSprites;
        smallCardsSprites = LoadData.smallCardsSprites;
        string name = addMazo.nameDeck;
        Debug.Log(name);
        /*if(init == 0)
        {
            RenderSelectedDeck("deck.dat");
            init = 1;
        }*/
        RenderSelectedDeck(name);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RenderSelectedDeck(string fileName)
    {
        Debug.Log(fileName);
        string path = "Assets/Data/Decks/"+fileName+".dat";
        deck = Serializator.DeserializeDeck(path);
        Debug.Log(fileName);
        List<string> cardIds;
        try
        {
            cardIds = deck.Cards;
        }
        catch(Exception e)
        {
            Deck deckAux = new Deck();
            deckAux.Id = "100";
            deckAux.Name = fileName;
            deckAux.Cards = new List<string>();
            foreach (Card c in LoadData.cardList)
            {
                deckAux.Cards.Add(c.id);
                break;
            }
            cardIds = deckAux.Cards;
            Serializator.SerializeDeck(deckAux);
            deck = deckAux;
        }

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
