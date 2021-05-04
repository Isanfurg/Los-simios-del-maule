using JsonReaderYugi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeckCardClickEvents : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    static Deck deck;
    void Start()
    {
        deck = RenderDeck.deck;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    private void RemoveCardId(string cardId)
    {
        
    }
}
