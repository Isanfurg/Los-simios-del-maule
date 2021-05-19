using JsonReaderYugi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Clase que se encarga del evento click del mouse sobre un mazo en la escena "SelectDeckScene"
public class DeckClick : MonoBehaviour, IPointerClickHandler
{   
    //Datos del mazo en pantalla
    public Text DeckName;
    public Text DeckSize;

    //Info del mazo seleccionado
    static List<Deck> decks;
    public static Deck selectedDeck;

    void Start()
    {
        decks = RenderDecks.decks;
        selectedDeck = null;
    }

    //Cuando se hace click sobre un mazo, se muestra la info de este en pantalla
    public void OnPointerClick(PointerEventData eventData)
    {
        string deckname = this.gameObject.transform.Find("DeckName").GetComponent<Text>().text;
        selectedDeck = FindDeck(deckname);
        DeckName.text = selectedDeck.Name;
        Debug.Log("Deck size: " + selectedDeck.Cards.Count);
        DeckSize.text = selectedDeck.Cards.Count+" cartas";

    }
    
    //Busca un mazo dentro de los mazos cargados en pantalla
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
