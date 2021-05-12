using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CardTT : MonoBehaviour
{
    public int id;
    public int atk;
    public int def;
    public string name;
    public string description;

    public string atribute;
    public int level;
    public string type;

    public string smallCardUrl;
    public string cardUrl;

    public CardTT(int id, int atk, int def, string name, string description, string smallCardUrl, string cardUrl)
    {
        this.id = id;
        this.atk = atk;
        this.def = def;
        this.name = name;
        this.description = description;
        this.smallCardUrl = smallCardUrl;
        this.cardUrl = cardUrl;
    }
    
}
