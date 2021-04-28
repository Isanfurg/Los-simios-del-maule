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
    
    public void Start()
    {

        for (int i = 0; i < 15; i++)
        {
            int randomIndex = 1;
            string[] maz = new string[2];
            maz[0] = "" + randomIndex;
            maz[1] = "mazo " + i;
            
            //button.transform.position = position;
            //button.GetComponent<RectTransform>().SetSize(size);
            //button.GetComponent<Button>().onClick.AddListener(method);

            GameObject newButton = Instantiate(pref,transform) as GameObject;
            newButton.name = "mazo " + i;
            newButton.GetComponentInChildren<Text>().text = "mazo " + i;
            newButton.SetActive(true);
        }
        

    }
}
