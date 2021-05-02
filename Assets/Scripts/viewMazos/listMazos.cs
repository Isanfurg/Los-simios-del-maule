using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class listMazos : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject pref;
  
    public ArrayList mazos;
  
    public viewLetters viewLetters;
    public void TaskOnClick()
    {
        viewLetters = GameObject.FindGameObjectWithTag("TagB").GetComponent<viewLetters>();
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
