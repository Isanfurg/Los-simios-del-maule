using JsonReaderYugi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class EditDeck : MonoBehaviour
{
    public GameObject preFab;
    CardList cards;
    List<JsonReaderYugi.Card> cardList;
    List<Sprite> cardBigImages = new List<Sprite>();
    void Start()
    {
        /*String path = "CardsID.txt";
        CardsLoader cLoader = new CardsLoader();
        cLoader.StartDownload(path);
        String pathC = "cards.dat";
        cards = Serializator.DeserializeCards(pathC);
        List<JsonReaderYugi.Card> ListOfCards = cards.cardList;
        foreach (JsonReaderYugi.Card card in ListOfCards)
        {
            card.ToString();
        }*/
        
        GameObject smallCardImage;
        String pathC = "cards.dat";
        cards = Serializator.DeserializeCards(pathC);
        cardList = cards.cardList;
        foreach(JsonReaderYugi.Card c in cardList) 
        {
            smallCardImage = (GameObject)Instantiate(preFab, transform);
            smallCardImage.GetComponent<Image>().sprite = LoadNewSprite("Assets/Resources/SmallCards/"+c.Id+".jpg");
            smallCardImage.name = c.Id;
            cardBigImages.Add(LoadNewSprite("Assets/Resources/Cards/" + c.Id + ".jpg"));

        }




    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startAux()
    {
        GameObject newObj;
        String pathC = "cards.dat";
        cards = Serializator.DeserializeCards(pathC);
        cardList = cards.cardList;
        foreach (JsonReaderYugi.Card c in cardList)
        {
            newObj = (GameObject)Instantiate(preFab, transform);
            newObj.GetComponent<Image>().sprite = LoadNewSprite("Assets/Resources/SmallCards/" + c.Id + ".jpg");

        }
    }
    public Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f)
    {

        // Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference
        Sprite NewSprite;

        Texture2D SpriteTexture = LoadTexture(FilePath);
        NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), PixelsPerUnit);

        return NewSprite;
    }

    public Texture2D LoadTexture(string FilePath)
    {

        // Load a PNG or JPG file from disk to a Texture2D
        // Returns null if load fails

        Texture2D Tex2D;
        byte[] FileData;

        if (File.Exists(FilePath))
        {
            FileData = File.ReadAllBytes(FilePath);
            Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
            if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
                return Tex2D;                 // If data = readable -> return texture
        }
        return null;                     // Return null if load failed
    }
}
