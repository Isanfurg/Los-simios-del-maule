using JsonReaderYugi;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Assets.Scripts.GameBoard;

public class Duelist : MonoBehaviour
{
    //public string name;
    //public string profileImg;
    //const int CARDS_DEAL_COUNT = 6;
    static Deck playerDeck;
    public GameObject PlayerHand;
    public GameObject PlayerDeck;
    public Image CardBacking;
    public GameField field;

    static List<Card> cardList;
    static List<Sprite> bigCardsSprites;
    static List<Sprite> smallCardsSprites;
    void Start()
    {
        GameField field = new GameField();
        LoadData instance = LoadData.GetInstance();
        cardList = instance.GetCardList();
        bigCardsSprites = instance.GetBigSprites();
        smallCardsSprites = instance.GetSmallSprites();
        playerDeck = DeckClick.selectedDeck;
        //sort list
        playerDeck.Cards.Shuffle();
        //take hand

    }
    public void DrawCard()
    {
        //get card id
        string cardID = playerDeck.Cards[0];
        //pop from card id list
        playerDeck.Cards.RemoveAt(0);
        //try to add 
        Card card = FindCard(cardID);
        if(card!= null)
        {
            // add card from deck to hand
            field.handZone.Add(card);
            //run annimation
             
            Sprite cardSprite = FindSmallCard(cardID);
            GameObject cardImage = new GameObject();
            cardImage.AddComponent<Image>().sprite = cardSprite;
            cardImage.transform.SetParent(PlayerHand.transform);
        }

    }
    private Card FindCard(string id)
    {
        foreach(Card card in cardList)
        {
            if(card.id == id)
            {
                return card;
            }
        }
        return null;
    }

    private Sprite FindSmallCard(string cardID)
    {
        foreach (Sprite cardSprite in smallCardsSprites)
        {
            if (cardID.Equals(cardSprite.name))
                return cardSprite;
        }

        return null;
    }
}
