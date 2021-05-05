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
    public static Deck deck;
    public static int init = 0;
    void Start()
    {
        cardList = LoadData.cardList;
        bigCardsSprites = LoadData.bigCardsSprites;
        smallCardsSprites = LoadData.smallCardsSprites;
        string name = addMazo.input.text + ".dat";
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
        string path = "Assets/Data/Decks/"+fileName;
        deck = Serializator.DeserializeDeck(path);
 
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
