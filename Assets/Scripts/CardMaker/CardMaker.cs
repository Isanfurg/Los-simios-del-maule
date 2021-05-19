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

//Clase para manejar la creación de cartas
public class CardMaker : MonoBehaviour
{   
    //Partes de la carta en la vista
    public GameObject CardTemplate;
    public GameObject CardLevel;
    public InputField CardNameInput;

    //Inputs donde se recibe la info de la carta
    public InputField CardDescriptionInput;
    public InputField CardAtkInput;
    public InputField CardDefInput;
    public InputField CardTypeInput;
    public Dropdown CardLevelInput;

    //Muestra la cantidad de caracteres de los inputs
    public Text CharCount;

    //Datos de la carta
    private string cardName;
    private string cardDescription;
    private string cardType;
    private int cardLevel;
    private int cardAtk;
    private int cardDef;

    //Datos de las cartas ya guardadas
    static List<JsonReaderYugi.Card> cardList;
    static List<Sprite> bigCardsSprites;
    static List<Sprite> smallCardsSprites;
    void Start()
    {   
        //Valores iniciales
        cardLevel = 1;
        CharCount.text = "";

        //Datos de las cartas ya guardadas
        LoadData instance = LoadData.GetInstance();
        cardList = instance.GetCardList();
        bigCardsSprites = instance.GetBigSprites();
        smallCardsSprites = instance.GetSmallSprites();

        //Límites de caracteres en los campos de texto
        CardNameInput.characterLimit = 23;
        CardDescriptionInput.characterLimit = 107;
        CardAtkInput.characterLimit = 6;
        CardDefInput.characterLimit = 6;
        CardTypeInput.characterLimit = 20;
        CardTemplate.transform.Find("CardArt").gameObject.GetComponent<UnityEngine.UI.Image>().sprite = null;


    }

    //Función asociada al input del nombre de la carta
    public void ReadCardName() {
        string s = CardNameInput.text;
        CharCount.text = s.Length + "/23";

        //Si el texto estrito es menor a 23 caracteres, se muestra en la pantalla
        if (s.Length <= 23)
        {
            cardName = s;
            Debug.Log(cardName);
            Text CardName = CardTemplate.transform.Find("CardName").gameObject.GetComponent<UnityEngine.UI.Text>();
            CardName.text = cardName;
        }
        
    }

    //Función asociada al input de la descripción de la carta
    public void ReadCardDescription() {
        string s = CardDescriptionInput.text;
        CharCount.text = s.Length + "/107";

        //Si el texto estrito es menor a 107 caracteres, se muestra en la pantalla
        if (s.Length <= 107)
        {   
            cardDescription = s;
            Debug.Log(cardDescription);
            Text CardDescription = CardTemplate.transform.Find("CardDescription").gameObject.GetComponent<UnityEngine.UI.Text>();
            CardDescription.text = cardDescription;
        }
    }

    //Función asociada al input del ataque de la carta
    public void ReadCardAtk() {
        string s = CardAtkInput.text;
        CharCount.text = s.Length + "/6";
        if (s.Length <= 6)
        {   
            //Comprueba que lo ingresado sea solo números
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
    //Función asociada al input de la ataque de la carta
    public void ReadCardDef() {
        string s = CardDefInput.text;
        CharCount.text = s.Length + "/6";
        if (s.Length <= 6)
        {
            //Comprueba que lo ingresado sea solo números
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

    //Función asociada al input dropdown de la ataque de la carta
    public void ReadCardLevel()
    {   
        //Limpia el nivel anterior
        foreach (Transform child in CardLevel.transform)
        {
            Destroy(child.gameObject);
        }

        //Agrega estrellas respecto al nivel escogido
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

    //Función asociada al input dropdown de la ataque de la carta
    public void ReadCardType()
    {
        string s = CardTypeInput.text;
        CharCount.text = s.Length + "/20";

        //Si el texto estrito es menor a 20 caracteres, se muestra en la pantalla
        if (s.Length <= 20)
        {         
            cardType = s;
            Text CardType = CardTemplate.transform.Find("CardType").gameObject.GetComponent<UnityEngine.UI.Text>();
            CardType.text = "["+s+"]";            
        }
    }

    //Botón para seleccionar la imagen de la carta
    //API recuperada desde https://github.com/gkngkc/UnityStandaloneFileBrowser
    public void SelectImageButton() {

        //Formatos admitidos
        var extensions = new[] {
            new ExtensionFilter("Image Files", "png", "jpg", "jpeg" )
        };

        var paths = StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, true);
        Image CardArt = CardTemplate.transform.Find("CardArt").gameObject.GetComponent<UnityEngine.UI.Image>();
        CardArt.sprite = LoadNewSprite(paths[0]);
    }

    //Botón para guardar la carta
    public void SaveCardButton()
    {   
        //Comprueba que los campos estén llenos y que se haya seleccionado una imagen
        bool areInputsEmpty = !(CardNameInput.text != "" && CardDescriptionInput.text != "" && CardAtkInput.text != "" && CardDefInput.text != "" && CardTypeInput.text != "");
        bool areImageEmpty = CardTemplate.transform.Find("CardArt").gameObject.GetComponent<UnityEngine.UI.Image>().sprite == null;
        bool isStorable = !areInputsEmpty && !areImageEmpty;

        //Si es guardable, se guarda. Si no, muestra un mensaje en pantalla
        if (isStorable)
            StartCoroutine(ExportCard());
        else
            CharCount.text = "Campos vacíos o falta imagen";
    }


    //Funciones para cargar un nuevo sprite desde una imagen en el computador.
    //Recuperadas desde https://forum.unity.com/threads/generating-sprites-dynamically-from-png-or-jpeg-files-in-c.343735/
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
            CardNameInput.text = "";
            CardDescriptionInput.text = "";
            CardAtkInput.text = "";
            CardDefInput.text = "";
            CardDescriptionInput.text = "";
            CardTypeInput.text = "";
            CardTemplate.transform.Find("CardArt").gameObject.GetComponent<UnityEngine.UI.Image>().sprite = null;
            CharCount.text = "Carta guardada";
       
            

        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            CharCount.text = "Error al guardar la carta";
        }



    }

    //Guarda la carta creada
    public void SaveCardCreated(byte[] bytes)
    {   
        //Guarda la info de la carta
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

        //Se serializan las cartas junto a la creada
        Serializator.SerializeCards(cl);

        //Se generan las imagenes correspondientes
        File.WriteAllBytes("Assets/Resources/Cards/" + card.Id + ".jpg", bytes);
        File.WriteAllBytes("Assets/Resources/SmallCards/" + card.Id + ".jpg", bytes);

        //Guarda los sprites creados en la listas en memoria
        Sprite bigSprite = LoadNewSprite("Assets/Resources/Cards/" + card.Id + ".jpg");
        Sprite smallSprite = LoadNewSprite("Assets/Resources/SmallCards/" + card.Id + ".jpg");
        bigSprite.name = card.Id;
        smallSprite.name = card.Id;
        bigCardsSprites.Add(bigSprite);
        smallCardsSprites.Add(smallSprite);

    }

    //Cuando se crea una carta genera un ID único para esta
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

    //Botón para cancelar la creación y volver al menú
    public void CancelButton(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

}
