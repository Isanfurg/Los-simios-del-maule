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

    void Start()
    {
        decks = RenderDecks.decks;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        string deckname = this.gameObject.transform.Find("DeckName").GetComponent<Text>().text;
        Deck thisdeck = FindDeck(deckname);
        DeckName.text = thisdeck.Name;
        Debug.Log("Deck size: " + thisdeck.Cards.Count);
        DeckSize.text = thisdeck.Cards.Count+" cartas";
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
