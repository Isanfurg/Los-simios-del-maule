using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace JsonReaderYugi
{
    class Serializator
    {
        public static void SerializeCards(CardList CardsList)
        {
            //string jsonString = JsonSerializer.Serialize(CardsList);
            string jsonString = JsonUtility.ToJson(CardsList);
            File.WriteAllText("cards.dat", jsonString);
        }
        public static CardList DeserializeCards(String path)
        {
            CardList ListOfCards;
            String jsonString = File.ReadAllText(path);
            //ListOfCards = JsonSerializer.Deserialize<List<Card>>(jsonString);
            ListOfCards = JsonUtility.FromJson<CardList>(jsonString);
            return ListOfCards;
        }

        public static void SerializeDeck(Deck deck)
        {
            deck.Id = "0";
            deck.Name = "deck";
            deck.Cards = new List<string>();
            deck.Cards.Add("23423");
            deck.Cards.Add("23423");
            deck.Cards.Add("23423");
            deck.Cards.Add("23423");
            deck.Cards.Add("23423");
            deck.Cards.Add("23423");
            deck.Cards.Add("23423");
            string jsonString = JsonUtility.ToJson(deck);
            File.WriteAllText("deck.dat", jsonString);
        }

        public static Deck DeserializeDeck(String path)
        {
            Deck deck;
            String jsonString = File.ReadAllText(path);
            deck = JsonUtility.FromJson<Deck>(jsonString);
            return deck;
        }

        
    }
}
