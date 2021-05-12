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
    public static string nameDeck;
    public static void SerializeName(string name)
    {
        try
        {
            //Open the File
            StreamWriter sw = new StreamWriter("Assets/Data/Dekcsnames.txt", true, Encoding.ASCII);
            //Writeout the numbers 1 to 10 on the same line.
            sw.WriteLine(name);
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
        TextWriter arch;
        arch = new StreamWriter("Assets/Data/Decks/"+input.text+".dat");
        nameDeck = input.text;
        SerializeName(nameDeck);

    }
    private Boolean validateName(string name)
    {
        using (StreamReader leer = new StreamReader("Assets/Data/Dekcsnames.txt"))
        {
            while (!leer.EndOfStream)
            {
                string nameNew = leer.ReadLine();
                Debug.Log(nameNew);
                if (nameNew.Equals(name))
                {
                    return false;
                }
            }
        }
        return true;
    }
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GameObject.FindGameObjectWithTag("add").GetComponent<Button>();
        string name = GameObject.FindGameObjectWithTag("nameMazo").GetComponent<InputField>().text;
        if (validateName(name+"\n"))
        {
            btn.onClick.AddListener(() => { TaskOnClick(); });
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
    
