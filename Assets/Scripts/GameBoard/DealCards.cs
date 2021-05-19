using JsonReaderYugi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Assets.Scripts.GameBoard;
public class DealCards : MonoBehaviour
{
    const int CARDS_DEAL_COUNT = 6;
    static Deck playerDeck;
    public GameObject PlayerHand;
    public GameObject PlayerDeck;
    public List<string> cardIDs;
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
        playerDeck.Cards.Shuffle();
        DealCardsPlayer();
       // Button btn1 = GameObject.FindGameObjectWithTag("DrawP1").GetComponent<Button>();
       // btn1.onClick.AddListener(() => { DrawCard(); });
       // Button btn2 = GameObject.FindGameObjectWithTag("DrawP2").GetComponent<Button>();
       // btn2.onClick.AddListener(() => { DrawCard(); });

    }


    //Agrega las cartas a la mano del jugador
    private void DealCardsPlayer()
    {   
        //Quita las cartas de arriba del mazo
        cardIDs = playerDeck.Cards;
        for(int i = 0; i < CARDS_DEAL_COUNT; i++)
        {
            DrawCard();
        }
        playerDeck.Cards = cardIDs;
    }

    private void DrawCard()
    {
        cardIDs = playerDeck.Cards;
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
        playerDeck.Cards = cardIDs;
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
