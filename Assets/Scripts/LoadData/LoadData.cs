using JsonReaderYugi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadData : MonoBehaviour
{
    private static CardList cards = null;
    //info img
    private static List<JsonReaderYugi.Card> cardList;
    //img high 
    private static List<Sprite> bigCardsSprites = new List<Sprite>();
    //img low
    private static List<Sprite> smallCardsSprites = new List<Sprite>();

    //Unique class instance
    private static LoadData instance = null;
    

    void Start()
    {   
        //inits class instance
        GetInstance();
    }
    
    private LoadData()
    {
        
    }

    public static LoadData GetInstance()
    {
        if(instance == null)
        {
            instance = new LoadData();
            instance.loadData();
        }
        return instance;
    }

    //
    private void loadData()
    {   
        //Carga los datos por primera y �nica vez
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

    //Carga una imagen cualquiera como sprite
    private Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f)
    {

        // Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference
        Sprite NewSprite;

        Texture2D SpriteTexture = LoadTexture(FilePath);
        NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), PixelsPerUnit);

        return NewSprite;
    }

    private Texture2D LoadTexture(string FilePath)
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

    public List<Card> GetCardList() { return cardList; }
    public List<Sprite> GetBigSprites() { return bigCardsSprites; }
    public List<Sprite> GetSmallSprites() { return smallCardsSprites; }


}
