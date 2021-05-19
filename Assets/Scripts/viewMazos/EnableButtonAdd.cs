using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnableButtonAdd : MonoBehaviour
{
    public Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn = GameObject.FindGameObjectWithTag("add").GetComponent<Button>();
        btn.interactable = false;

    }

    // Update is called once per frame
    void Update()
    {
      
    }

}    
