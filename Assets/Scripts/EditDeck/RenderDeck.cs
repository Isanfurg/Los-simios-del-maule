using JsonReaderYugi;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Clase que se encarga de mostrar las cartas del mazo que se está editando en la escena "EditDeckScene"
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
        //Referencias a los datos cargados en memoria anteriormente
        LoadData instance = LoadData.GetInstance();
        cardList = instance.GetCardList();
        bigCardsSprites = instance.GetBigSprites();
        smallCardsSprites = instance.GetSmallSprites();
        string name = addMazo.nameDeck;

        RenderSelectedDeck(name);
        

    }

    //Muestra las cartas del mazo seleccionado
    public void RenderSelectedDeck(string fileName)
    {
        //Desserializa el mazo
        string path = "Assets/Data/Decks/"+fileName+".dat";
        deck = Serializator.DeserializeDeck(path);
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
            foreach (Card c in cardList)
            {
                deckAux.Cards.Add(c.id);
                break;
            }
            cardIds = deckAux.Cards;
            Serializator.SerializeDeck(deckAux);
            deck = deckAux;
        }

        //Muestra las cartas del mazo
        GameObject smallCardImage;
        foreach (string cardId in cardIds)
        {
            smallCardImage = (GameObject)Instantiate(preFab, transform);
            smallCardImage.GetComponent<Image>().sprite = FindSmallCard(cardId);

        }
        
       
    }

    //Busca el sprite pequeño (en baja resolución) de una carta dada su ID
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
