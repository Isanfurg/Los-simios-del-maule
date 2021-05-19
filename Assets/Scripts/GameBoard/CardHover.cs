using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image CardView;

    void Start()
    {
       // CardView.enabled = false;
       
    }

    //Cuando entra el puntero, aparece la imagen grande de la carta
    public void OnPointerEnter(PointerEventData eventData)
    {
        CardView.enabled = true;
        Sprite smallCardSprite = this.gameObject.GetComponent<Image>().sprite;
        string smallCardID = smallCardSprite.name;

        Sprite bigCardSprite = SearchSprite(smallCardID);

        CardView.sprite = bigCardSprite;

    }

    //Cuando sale el puntero, la imagen grande se deshabilita
    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    //Busca el sprite grande de la carta dentro de la lista de sprites grandes
    private Sprite SearchSprite(string cardID)
    {
        LoadData data = LoadData.GetInstance();
        foreach(Sprite sprite in data.GetBigSprites())
        {
            if (cardID.Equals(sprite.name))
                return sprite;
        }

        return null;
    }
}
