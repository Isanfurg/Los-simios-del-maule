using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class viewLetters : MonoBehaviour
{
    public GameObject preF2;
    public EditDeck editDeck;
    // Start is called before the first frame update
    void Start()
    {
        aux();
    }
    public void aux()
    {
        //Console.WriteLine("LLEga");
        editDeck = GameObject.FindGameObjectWithTag("TagA").GetComponent<EditDeck>();
        editDeck.startAux(preF2);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
