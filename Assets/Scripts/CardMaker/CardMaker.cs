using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using JsonReaderYugi;
using UnityEngine.SceneManagement;
using SFB;

public class CardMaker : MonoBehaviour
{

    public GameObject CardTemplate;
    public GameObject CardLevel;
    public InputField CardNameInput;
    public InputField CardDescriptionInput;
    public InputField CardAtkInput;
    public InputField CardDefInput;
    public InputField CardTypeInput;
    public Dropdown CardLevelInput;
    public Text CharCount;
    private string cardName;
    private string cardDescription;
    private string cardType;
    private int cardLevel;
    private int cardAtk;
    private int cardDef;
    static List<JsonReaderYugi.Card> cardList;
    static List<Sprite> bigCardsSprites;
    static List<Sprite> smallCardsSprites;
    void Start()
    {
        CharCount.text = "";
        cardList = LoadData.cardList;
        bigCardsSprites = LoadData.bigCardsSprites;
        smallCardsSprites = LoadData.smallCardsSprites;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadCardName(string s) {
        CharCount.text = s.Length + "/23";
        if (s.Length <= 23)
        {
            
            cardName = s;
            Debug.Log(cardName);
            Text CardName = CardTemplate.transform.Find("CardName").gameObject.GetComponent<UnityEngine.UI.Text>();
            CardName.text = cardName;
        }
        
    }

    public void ReadCardDescription(string s) {
        CharCount.text = s.Length + "/107";
        if (s.Length <= 107)
        {
            cardDescription = s;
            Debug.Log(cardDescription);
            Text CardDescription = CardTemplate.transform.Find("CardDescription").gameObject.GetComponent<UnityEngine.UI.Text>();
            CardDescription.text = cardDescription;
        }
    }

    public void ReadCardAtk(string s) {
        CharCount.text = s.Length + "/6";
        if (s.Length <= 6)
        {
            if (Int32.TryParse(s, out int j))
            {
                cardAtk = j;
                Debug.Log(cardAtk);
                Text CardAtk = CardTemplate.transform.Find("CardAtk").gameObject.GetComponent<UnityEngine.UI.Text>();
                CardAtk.text = s;
            }
            else
            {
                CardAtkInput.Select();
                CardAtkInput.text = "";
            }
        }
        
    }

    public void ReadCardDef(string s) {
        CharCount.text = s.Length + "/6";
        if (s.Length <= 6)
        {
            if (Int32.TryParse(s, out int j))
            {
                cardDef = j;
                Debug.Log(cardDef);
                Text CardDef = CardTemplate.transform.Find("CardDef").gameObject.GetComponent<UnityEngine.UI.Text>();
                CardDef.text = s;
            }
            else
            {
                CardDefInput.Select();
                CardDefInput.text = "";
            }
        }
    }

    public void ReadCardLevel()
    {
        foreach (Transform child in CardLevel.transform)
        {
            Destroy(child.gameObject);
        }
        cardLevel = CardLevelInput.value + 1;
        for (int i = 0; i < cardLevel; i++)
        {
            GameObject star = new GameObject();
            Sprite starSprite = LoadNewSprite("Assets/Images/UI/starball.png");
            Image starImage = star.gameObject.AddComponent<Image>();
            starImage.sprite = starSprite;
            starImage.transform.SetParent(CardLevel.transform);
            starImage.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void ReadCardType(string s)
    {
        CharCount.text = s.Length + "/20";
        if (s.Length <= 20)
        {         
            cardType = s;
            Text CardType = CardTemplate.transform.Find("CardType").gameObject.GetComponent<UnityEngine.UI.Text>();
            CardType.text = "["+s+"]";            
        }
    }

    public void SelectImageButton() {

        //string path = EditorUtility.OpenFilePanel("Seleccione una imagen", "", "jpg");
        var extensions = new[] {
            new ExtensionFilter("Image Files", "png", "jpg", "jpeg" )
        };
        var paths = StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, true);
        Image CardArt = CardTemplate.transform.Find("CardArt").gameObject.GetComponent<UnityEngine.UI.Image>();
        CardArt.sprite = LoadNewSprite(paths[0]);
    }

    public void SaveCardButton()
    {
        if (CardNameInput.text != "" && CardDescriptionInput.text != "" && CardAtkInput.text != "" && CardDefInput.text != "")
            StartCoroutine(ExportCard());
        else
            CharCount.text = "Ningun campo de texto debe estar vacio";
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

    WaitForSeconds waitTime = new WaitForSeconds(0.1F);
    WaitForEndOfFrame frameEnd = new WaitForEndOfFrame();
    public IEnumerator ExportCard()
    {
        yield return waitTime;
        yield return frameEnd;

        try
        {
            
            int width = 380;
            int height = 535;
            Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
            Rect sel = new Rect();
            sel.width = width;
            sel.height = height;
            sel.x = CardTemplate.transform.position.x - 190;
            sel.y = CardTemplate.transform.position.y - 265;

            tex.ReadPixels(sel, 0, 0);

            byte[] bytes = tex.EncodeToJPG();

            SaveCardCreated(bytes);
            CharCount.text = "Carta guardada";
            CardNameInput.text = "";
            CardDescriptionInput.text = "";
            CardAtkInput.text = "";
            CardDefInput.text = "";
            CardDescriptionInput.text = "";
            CardTypeInput.text = "";
            CardTemplate.transform.Find("CardArt").gameObject.GetComponent<UnityEngine.UI.Image>().sprite = null;

        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            CharCount.text = "Error al guardar la carta";
        }



    }

    public void SaveCardCreated(byte[] bytes)
    {
        Card card = new Card();
        card.Name = cardName;
        card.Desc = cardDescription;
        card.Atk = cardAtk;
        card.Def = cardDef;
        card.Id = generateID().ToString();
        card.Type = cardType;
        card.Level = cardLevel;
        cardList.Add(card);
        CardList cl = new CardList();
        cl.cardList = cardList;
        Serializator.SerializeCards(cl);
        File.WriteAllBytes("Assets/Resources/Cards/" + card.Id + ".jpg", bytes);
        File.WriteAllBytes("Assets/Resources/SmallCards/" + card.Id + ".jpg", bytes);
        Sprite bigSprite = LoadNewSprite("Assets/Resources/Cards/" + card.Id + ".jpg");
        Sprite smallSprite = LoadNewSprite("Assets/Resources/SmallCards/" + card.Id + ".jpg");
        bigSprite.name = card.Id;
        smallSprite.name = card.Id;
        bigCardsSprites.Add(bigSprite);
        smallCardsSprites.Add(smallSprite);

    }

    private int generateID()
    {
        System.Random r = new System.Random();
        int id = r.Next(1, 9999999);
        foreach(Card c in cardList)
        {
            if (Int32.Parse(c.Id) == id)
                return generateID();
        }
        return id;
    }

    public void CancelButton(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

}
