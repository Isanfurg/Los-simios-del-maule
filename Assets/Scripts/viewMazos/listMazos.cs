using JsonReaderYugi;
using Newtonsoft.Json;
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
    public viewCard2 view;
    public void TaskOnClick(string name)
    {
        view = GameObject.FindGameObjectWithTag("contt").GetComponent<viewCard2>();
        //Thread.Sleep(4000);
        view.aux(name);
        
    }
   
    public void Start()
    {
    

        using (StreamReader leer = new StreamReader("Assets/Data/Dekcsnames.txt"))
        {
            while (!leer.EndOfStream)
            {
                string name = leer.ReadLine();
                GameObject newButton = Instantiate(pref, transform) as GameObject;
                newButton.name = name;
                newButton.GetComponentInChildren<Text>().text = name;
                newButton.SetActive(true);
                Button btn = newButton.GetComponent<Button>();
                btn.image.rectTransform.sizeDelta = new Vector2(50, 50);
                btn.onClick.AddListener(() => { TaskOnClick(btn.name); });
            }
        }

    }
}
