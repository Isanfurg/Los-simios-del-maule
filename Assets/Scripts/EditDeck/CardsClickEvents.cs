using JsonReaderYugi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardsClickEvents : MonoBehaviour, IPointerClickHandler
{
    public GameObject DeckContent;
    static Deck deck;
    void Start()
    {
        deck = RenderDeck.deck;
    }

    void Update()
    {
        
    }

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
