using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card")]
public class Card : ScriptableObject
{
    public Sprite cardArt;
    public string cardDescription;
    public string cardName;
    public string cardAtk;
    public string cardDef;
}
