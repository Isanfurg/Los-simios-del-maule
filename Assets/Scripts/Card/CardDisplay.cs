using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Image CardArt;
    public Text CardName;
    public Text CardDescription;
    public Text CardAtk;
    public Text CardDef;
    public Card card;

    void Start()
    {
        renderCard();
    }

    void renderCard() 
    {
        CardArt.sprite = card.cardArt;
        CardName.text = card.cardName;
        CardDescription.text = card.cardDescription;
        CardAtk.text = card.cardAtk;
        CardDef.text = card.cardDef;
    }

}
