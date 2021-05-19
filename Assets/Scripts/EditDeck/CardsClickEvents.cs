using JsonReaderYugi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Clase para manejar el evento de click izquierdo, para cada carta disponible, en la escena "Edit Deck"
public class CardsClickEvents : MonoBehaviour, IPointerClickHandler
{   
    //Información del deck en pantalla y sus datos
    public GameObject DeckContent;
    static Deck deck;
    void Start()
    {   
        //Mazo que se está editando
        deck = RenderDeck.deck;
    }

    void Update()
    {
        
    }

    //Al hacer click izquierdo sobre una carta disponible, se genera una copia de la carta y se agrega al mazo que se esté editando
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Sprite selCardSprite = this.gameObject.GetComponent<Image>().sprite;
            string selCardId = selCardSprite.name;
            Debug.Log(selCardId);
            deck.Cards.Add(selCardId);
            Transform CardClone = Instantiate(this.transform);
            Destroy(CardClone.gameObject.GetComponent<CardsClickEvents>());
            CardClone.gameObject.AddComponent<DeckCardClickEvents>();
            CardClone.SetParent(DeckContent.transform);
        }
            
    }
}
