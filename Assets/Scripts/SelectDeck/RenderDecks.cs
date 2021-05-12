using JsonReaderYugi;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RenderDecks : MonoBehaviour
{
    public GameObject preFab;
    public static List<Deck> decks;
    private void Start()
    {
        RenderAllDecks();
    }

    private void RenderAllDecks()
    {
        decks = new List<Deck>();
        string path = "Assets/Data/Dekcsnames.txt";
        IEnumerable<string> decknames = File.ReadLines(path);
        foreach(string deckname in decknames)
        {
            Deck deck = Serializator.DeserializeDeck("Assets/Data/Decks/" + deckname + ".dat");
            decks.Add(deck);
        }

        foreach (Deck deck in decks)
        {
            GameObject deckPrefab = (GameObject)Instantiate(preFab, transform);
            Text DeckName = deckPrefab.transform.Find("DeckName").GetComponent<Text>();
            DeckName.text = deck.Name;
      

        }
    }
}
