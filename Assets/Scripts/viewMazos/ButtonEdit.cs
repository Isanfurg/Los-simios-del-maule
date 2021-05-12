using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class ButtonEdit : MonoBehaviour
{
    public static string namebtn;
    // Start is called before the first frame update
    public void editarMazo()
    {
        using (StreamReader leer = new StreamReader("Assets/Data/ultimoMazo.txt"))
        {
            addMazo.nameDeck = leer.ReadLine();
        }
    }
}
