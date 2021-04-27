using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;

public class CardMaker : MonoBehaviour
{

    public GameObject CardTemplate;
    private string cardName;
    private string cardDescription;
    private string cardAtk;
    private string cardDef;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadCardName(string s) {
        cardName = s;
        Debug.Log(cardName);
        Text CardName = CardTemplate.transform.Find("CardName").gameObject.GetComponent<UnityEngine.UI.Text>();
        CardName.text = cardName;
    }

    public void ReadCardDescription(string s) {
        cardDescription = s;
        Debug.Log(cardDescription);
        Text CardDescription = CardTemplate.transform.Find("CardDescription").gameObject.GetComponent<UnityEngine.UI.Text>();
        CardDescription.text = cardDescription;
    }

    public void ReadCardAtk(string s) {
        cardAtk = s;
        Debug.Log(cardAtk);
        Text CardAtk = CardTemplate.transform.Find("CardAtk").gameObject.GetComponent<UnityEngine.UI.Text>();
        CardAtk.text = cardAtk;
    }

    public void ReadCardDef(string s) {
        cardDef = s;
        Debug.Log(cardDef);
        Text CardDef = CardTemplate.transform.Find("CardDef").gameObject.GetComponent<UnityEngine.UI.Text>();
        CardDef.text = cardDef;
    }

    public void SelectImageButton() {

        string path = EditorUtility.OpenFilePanel("Seleccione una imagen", "", "jpg");
        Image CardArt = CardTemplate.transform.Find("CardArt").gameObject.GetComponent<UnityEngine.UI.Image>();
        CardArt.sprite = LoadNewSprite(path);
        /*myTexture = Resources.Load("/Assets/Images/Artwork/doraemon.jpg") as Texture2D;

        GameObject rawImage = CardTemplate.transform.Find("CardArt").gameObject;

        rawImage.GetComponent*/

        /*string path = EditorUtility.OpenFilePanel("Seleccione una imagen", "", "jpg");
        Image CardArt = CardTemplate.transform.Find("CardArt").gameObject.GetComponent<UnityEngine.UI.Image>();
        Debug.Log(path);
        Sprite image = Resources.Load<Sprite>("/Assets/Images/Artwork/doraemon.jpg");
        CardArt.sprite = image;*/
    }

    public Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f) {

        // Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference
        Sprite NewSprite;

        Texture2D SpriteTexture = LoadTexture(FilePath);
        NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), PixelsPerUnit);
        
        return NewSprite;
    }

    public Texture2D LoadTexture(string FilePath) {

        // Load a PNG or JPG file from disk to a Texture2D
        // Returns null if load fails

        Texture2D Tex2D;
        byte[] FileData;

        if (File.Exists(FilePath)) {
            FileData = File.ReadAllBytes(FilePath);
            Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
            if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
                return Tex2D;                 // If data = readable -> return texture
        }
        return null;                     // Return null if load failed
    }

}
