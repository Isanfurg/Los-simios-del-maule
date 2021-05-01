using JsonReaderYugi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadData : MonoBehaviour
{
    // Start is called before the first frame update
    static CardList cards = null;
    //info img
    public static List<JsonReaderYugi.Card> cardList;
    //img high 
    public static List<Sprite> bigCardsSprites = new List<Sprite>();
    //img low
    public static List<Sprite> smallCardsSprites = new List<Sprite>();

    void Start()
    {
        loadData();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void loadData()
    {
        if (cards == null)
        {
            Debug.Log("Loading cards...");
            String pathC = "cards.dat";
            cards = Serializator.DeserializeCards(pathC);
            cardList = cards.cardList;
            Sprite bigCardSprite;
            Sprite smallCardSprite;
            foreach (JsonReaderYugi.Card c in cardList)
            {
                bigCardSprite = LoadNewSprite("Assets/Resources/Cards/" + c.Id + ".jpg");
                smallCardSprite = LoadNewSprite("Assets/Resources/SmallCards/" + c.Id + ".jpg");
                bigCardSprite.name = c.Id;
                smallCardSprite.name = c.Id;
                bigCardsSprites.Add(bigCardSprite);
                smallCardsSprites.Add(smallCardSprite);

            }
            
        }
        Debug.Log("bigcards size: " + bigCardsSprites.Count);
        Debug.Log("smallcards size: " + smallCardsSprites.Count);
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
