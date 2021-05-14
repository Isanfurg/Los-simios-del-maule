using JsonReaderYugi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hover : MonoBehaviour, IPointerEnterHandler
{
    public Image bigImage;
    static List<Card> cardList;
    static List<Sprite> bigCardsSprites;
    static List<Sprite> smallCardsSprites;
    void Start()
    {
        LoadData instance = LoadData.GetInstance();
        cardList = instance.GetCardList();
        bigCardsSprites = instance.GetBigSprites();
        smallCardsSprites = instance.GetSmallSprites();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData data)
    {
        bigImage.sprite = FindBigCardSprite(this.GetComponent<Image>().sprite.name);
    }

    public Sprite FindBigCardSprite(string cardId)
    {
        foreach(Sprite card in bigCardsSprites)
        {
            if (cardId.Equals(card.name))
            {
                return card;
            }
        }
        return null;
    }
}
