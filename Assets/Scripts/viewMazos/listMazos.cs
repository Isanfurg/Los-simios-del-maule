using JsonReaderYugi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class listMazos : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject pref;
    public viewLetters viewLetters;
    public void TaskOnClick()
    {
        viewLetters = GameObject.FindGameObjectWithTag("contt").GetComponent<viewLetters>();
        //Thread.Sleep(4000);
        viewLetters.aux();
        
    }
    public void Start()
    {

       for(int i = 0; i < 15; i++)
        {
            
            GameObject newButton = Instantiate(pref, transform) as GameObject;
            newButton.name = "mazo "+i;
            newButton.GetComponentInChildren<Text>().text = "mazo "+i;
            newButton.SetActive(true);  
            Button btn = newButton.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
        }
           

    }
}
