using JsonReaderYugi;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Clase para mostrar los mazos disponibles en la escena "SelectDeckScene"
public class RenderDecks : MonoBehaviour
{
    public GameObject preFab;
    public static List<Deck> decks;
    private void Start()
    {
        RenderAllDecks();
    }

    //Muestra todos los mazos disponibles 
    private void RenderAllDecks()
    {   
        //Guarda los mazos disponibles
        decks = new List<Deck>();
        
        //Obtiene los nombres de los mazos desde el archivo "Dekcsnames.txt"
        string path = "Assets/Data/Dekcsnames.txt";
        IEnumerable<string> decknames = File.ReadLines(path);

        //Deserializa y carga los mazos en la lista
        foreach(string deckname in decknames)
        {
            Deck deck = Serializator.DeserializeDeck("Assets/Data/Decks/" + deckname + ".dat");
            decks.Add(deck);
        }

        //Muestra los mazos en pantalla
        foreach (Deck deck in decks)
        {
            GameObject deckPrefab = (GameObject)Instantiate(preFab, transform);
            Text DeckName = deckPrefab.transform.Find("DeckName").GetComponent<Text>();
            DeckName.text = deck.Name;
      

        }
    }
}
