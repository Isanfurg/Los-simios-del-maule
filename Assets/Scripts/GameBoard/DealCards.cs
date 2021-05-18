using JsonReaderYugi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DealCards : MonoBehaviour
{
    const int CARDS_DEAL_COUNT = 6;
    static Deck playerDeck;
    public GameObject PlayerHand;
    public GameObject PlayerDeck;

    static List<Card> cardList;
    static List<Sprite> bigCardsSprites;
    static List<Sprite> smallCardsSprites;
    public Image CardView;

    //Obtiene los datos de las cartas junto con el mazo seleccionado por el jugador
    void Start()
    {

        LoadData instance = LoadData.GetInstance();
        cardList = instance.GetCardList();
        bigCardsSprites = instance.GetBigSprites();
        smallCardsSprites = instance.GetSmallSprites();
        playerDeck = DeckClick.selectedDeck;
        DealCardsPlayer();
    }


    //Agrega las cartas a la mano del jugador
    private void DealCardsPlayer()
    {   
        //Quita las cartas de arriba del mazo
        List<string> cardIDs = playerDeck.Cards;
        for(int i = 0; i < CARDS_DEAL_COUNT; i++)
        {
            string cardID = cardIDs[cardIDs.Count - 1];
            cardIDs.RemoveAt(cardIDs.Count - 1);
            Sprite cardSprite = FindSmallCard(cardID);
            GameObject cardImage = new GameObject();
            cardImage.AddComponent<DragDropCard>();
            cardImage.AddComponent<CardHover>().CardView = CardView;
            CanvasGroup c = cardImage.AddComponent<CanvasGroup>();
            c.interactable = true;
            c.blocksRaycasts = true;
            cardImage.AddComponent<Image>().sprite = cardSprite;
            cardImage.transform.SetParent(PlayerHand.transform);
        }
    }

    //Obtiene el sprite de una carta con su ID
    private Sprite FindSmallCard(string cardID)
    {
        foreach(Sprite cardSprite in smallCardsSprites)
        {
            if (cardID.Equals(cardSprite.name))
                return cardSprite;
        }

        return null;
    }


}
