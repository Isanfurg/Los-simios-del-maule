using JsonReaderYugi;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
            UIScenes changer = new UIScenes();
            changer.LoadScene("MenuScene");
        }
        else
        {
            Alert.text = "El mazo debe tener entre 20 y 40 cartas";
        }
    }
    public void SerializeDeck()
    {
        deck = RenderDeck.deck;

        int deckSize = deck.Cards.Count;
        if (deckSize >= 20 && deckSize <= 40)
        {
            string jsonString = JsonConvert.SerializeObject(deck, Formatting.Indented);
            //Console.WriteLine(jsonString);
            File.WriteAllText(addMazo.input.text + ".dat", jsonString);
            Alert.text = "Mazo guardado";
        }
        else
        {
            Alert.text = "El mazo debe tener entre 20 y 40 cartas";
        }
        

        //Console.WriteLine("Deck " + fileName + " Serializado Exitosamente!");
    }
}
