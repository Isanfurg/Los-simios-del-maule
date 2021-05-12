using JsonReaderYugi;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class viewCard : MonoBehaviour
{
    public GameObject preff;
    public static Deck deck;
    public List<String> cardList;
    public List<Sprite> cardBigImages = new List<Sprite>();
    // Start is called before the first frame update
    void Start()
    {

    }
    public void aux(string deckName)
    {
        cardBigImages = new List<Sprite>();
        GameObject smallCardImage;
        using (StreamWriter leer = new StreamWriter("Assets/Data/ultimoMazo.txt"))
        {
            leer.WriteLine(deckName);
        }

        string pathC = "Assets/Data/Decks/" + deckName + ".dat";

        deck = Serializator.DeserializeDeck(pathC);
        cardList = deck.Cards;
        Debug.Log("Cantidad de cartas: " + cardList.Count);

        foreach (string cardId in cardList)
        {
            smallCardImage = (GameObject)Instantiate(preff, transform);
            smallCardImage.GetComponent<Image>().sprite = LoadNewSprite("Assets/Resources/SmallCards/" + cardId + ".jpg");
            smallCardImage.name = cardId;
            cardBigImages.Add(LoadNewSprite("Assets/Resources/Cards/" + cardId + ".jpg"));

        }

    }
    // Update is called once per frame
    void Update()
    {
        /*GameObject p = GameObject.FindGameObjectWithTag("ScrollView_viewLetters").GetComponent<GameObject>();
        p.*/
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
