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


    void Start()
    {
        renderCard();
    }

    void renderCard() 
    {
        CardName.text = "Nombre de la carta";
        CardDescription.text = "Descripción de la carta";
        CardAtk.text = "99999";
        CardDef.text = "99999";
    }

}
