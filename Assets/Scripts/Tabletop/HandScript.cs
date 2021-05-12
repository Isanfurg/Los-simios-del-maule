using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    GameObject hand;
    GameObject cardInHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hand = GameObject.Find("PlayerHand");
        cardInHand = GameObject.Find("CardPreview");

    }
}
