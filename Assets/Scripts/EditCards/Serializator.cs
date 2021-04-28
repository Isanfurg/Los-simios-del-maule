﻿using System;
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
    }
}