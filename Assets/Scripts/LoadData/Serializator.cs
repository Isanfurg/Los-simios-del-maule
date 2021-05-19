using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace JsonReaderYugi
{   
    //Clase para serializar y deserializar la información de las cartas y mazos
    class Serializator
    {   
        //Serializa una lista de cartas
        public static void SerializeCards(CardList CardsList)
        {
            //string jsonString = JsonSerializer.Serialize(CardsList);
            string jsonString = JsonUtility.ToJson(CardsList);
            File.WriteAllText("cards.dat", jsonString);
        }

        //Deserializa una lista de cartas
        public static CardList DeserializeCards(String path)
        {
            CardList ListOfCards;
            String jsonString = File.ReadAllText(path);
            //ListOfCards = JsonSerializer.Deserialize<List<Card>>(jsonString);
            ListOfCards = JsonUtility.FromJson<CardList>(jsonString);
            return ListOfCards;
        }

        //Serializa un mazo 
        public static void SerializeDeck(Deck deck)
        {
            string jsonString = JsonUtility.ToJson(deck);
            File.WriteAllText("Assets/Data/Decks/"+ deck.Name +".dat", jsonString);
            Debug.Log("Serializado: " + deck.Name);
        }
        
        //Deserializa un mazo
        public static Deck DeserializeDeck(String path)
        {
            Deck deck;
            String jsonString = File.ReadAllText(path);
            deck = JsonUtility.FromJson<Deck>(jsonString);
            return deck;
        }

        
    }
}
