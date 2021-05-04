using JsonReaderYugi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneScript : MonoBehaviour
{
    public Text Alert;
    public static Deck deck;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveButton()
    {
        deck = RenderDeck.deck;
        int deckSize = deck.Cards.Count;
        if(deckSize >= 20 && deckSize <= 40)
        {
            Serializator.SerializeDeck(deck);
            Alert.text = "Mazo guardado";
        }
        else
        {
            Alert.text = "El mazo debe tener entre 20 y 40 cartas";
        }
    }
}
