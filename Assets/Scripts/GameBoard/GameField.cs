using JsonReaderYugi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{
    public int lifePoints;
    public List<Card> magicZone;
    public List<Card> monsterZone;
    public List<Card> handZone;
    public GameObject PlayerHand;

    public GameField()
    {
        magicZone = new List<Card>();
        monsterZone = new List<Card>();
        handZone = new List<Card>();
        lifePoints = 4000;
    }


}
