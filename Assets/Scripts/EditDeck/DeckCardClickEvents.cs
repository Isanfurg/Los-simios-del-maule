using JsonReaderYugi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Clase para manejar el evento de click derecho, para cada carta del mazo, en la escena "Edit Deck"
public class DeckCardClickEvents : MonoBehaviour, IPointerClickHandler
{
    
    static Deck deck;
    void Start()
    {
        //Mazo que se est� editando
        deck = RenderDeck.deck;
    }


    //Al hacer click derecho sobre una carta del mazo que se est� editando, esta se elimina de la pantalla
    //y tambi�n se borra su informaci�n dentro del mazo
    public void OnPointerClick(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Sprite selCardSprite = this.gameObject.GetComponent<Image>().sprite;
            string selCardId = selCardSprite.name;
            Debug.Log(selCardId);
            deck.Cards.Remove(selCardId);
            Destroy(this.gameObject);

        }

    }

}
