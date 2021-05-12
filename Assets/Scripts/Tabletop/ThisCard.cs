using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardGame : MonoBehaviour
{
    public List<CardTT> cardGame = new List<CardTT>();
    public int thisId;

    public int id;
    public int atk;
    public int def;
    public string name;
    public string description;

    public Text idText;
    public Text atkText;
    public Text defText;
    public Text nameText;
    public Text descriptionText;

    // Start is called before the first frame update
    void Start()
    {
        cardGame[0] = DeckTT.cardList[thisId];
    }

    // Update is called once per frame
    void Update()
    {
        id = cardGame[0].id;
        atk = cardGame[0].atk;
        def = cardGame[0].def;
        name = cardGame[0].name;
        description = cardGame[0].description;

        idText.text = ""+id;
        atkText.text = ""+atk;
        defText.text = ""+def;
        nameText.text = ""+name;
        descriptionText.text = ""+description;
    }
}
