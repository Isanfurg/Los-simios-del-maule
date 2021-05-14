using JsonReaderYugi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeckClick : MonoBehaviour, IPointerClickHandler
{
    public Text DeckName;
    public Text DeckSize;
    static List<Deck> decks;
    public static Deck selectedDeck;

    void Start()
    {
        decks = RenderDecks.decks;
        selectedDeck = null;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        string deckname = this.gameObject.transform.Find("DeckName").GetComponent<Text>().text;
        selectedDeck = FindDeck(deckname);
        DeckName.text = selectedDeck.Name;
        Debug.Log("Deck size: " + selectedDeck.Cards.Count);
        DeckSize.text = selectedDeck.Cards.Count+" cartas";

    }
    

    private Deck FindDeck(string deckname)
    {
        foreach (Deck deck in decks)
        {
            if (deckname.Equals(deck.Name))
            {
                return deck;
            }
                
        }

        return null;
    }
}
