using JsonReaderYugi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class addMazo : MonoBehaviour
{
    public static InputField input;
    public static string deckName;
    public static void SerializeName(string name)
    {
        try
        {
            //Open the File
            StreamWriter sw = new StreamWriter("Assets/Data/Dekcsnames.txt", true, Encoding.ASCII);
            //Writeout the numbers 1 to 10 on the same line.
            sw.Write("\n"+name);
            //close the file
            sw.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        }
    }

    public void TaskOnClick()
    {
        input = GameObject.FindGameObjectWithTag("nameMazo").GetComponent<InputField>();
        new StreamWriter("Assets/Data/Decks/"+input.text+".dat");
        deckName = input.text;
        SerializeName(deckName);

    }

    public void TaskOnClickEdit()
    {
        //createDeck = false;
        deckName = listMazos.btnName;
    }
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GameObject.FindGameObjectWithTag("add").GetComponent<Button>();
        btn.onClick.AddListener(() => { TaskOnClick(); });

        Button editBtn = GameObject.FindGameObjectWithTag("edit_button").GetComponent<Button>();
        editBtn.onClick.AddListener(() => { TaskOnClickEdit(); });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
    
