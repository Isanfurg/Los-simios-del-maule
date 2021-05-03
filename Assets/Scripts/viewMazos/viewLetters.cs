using JsonReaderYugi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class viewLetters : MonoBehaviour
{
    public GameObject preff;
    public EditDeck editDeck;
    CardList cards2;
    public ArrayList mazos;
    public List<JsonReaderYugi.Card> cardList2;
    public List<Sprite> cardBigImages2 = new List<Sprite>();
    // Start is called before the first frame update
    void Start()
    {
        aux();
    }
    public void aux()
    {
        editDeck = GameObject.FindGameObjectWithTag("TagA").GetComponent<EditDeck>();
        cardList2 = editDeck.cardList;
        cardBigImages2 = editDeck.cardBigImages;
        GameObject smallCardImage;
        String pathC = "cards.dat";
        cards2 = Serializator.DeserializeCards(pathC);
        cardList2 = cards2.cardList;

        foreach (JsonReaderYugi.Card c in cardList2)
        {
            smallCardImage = (GameObject)Instantiate(preff, transform);
            smallCardImage.GetComponent<Image>().sprite = editDeck.LoadNewSprite("Assets/Resources/SmallCards/" + c.Id + ".jpg");
            smallCardImage.name = c.Id;
            cardBigImages2.Add(editDeck.LoadNewSprite("Assets/Resources/Cards/" + c.Id + ".jpg"));

        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
