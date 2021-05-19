using JsonReaderYugi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class addMazo : MonoBehaviour
{
    public static InputField input;
    public static string nameDeck;
    private Boolean validateName(string name)
    {
        using (StreamReader leer = new StreamReader("Assets/Data/Dekcsnames.txt"))
        {
            while (!leer.EndOfStream)
            {
                string nameNew = leer.ReadLine();
                Debug.Log(nameNew);
                if (nameNew==name)
                {
                    return false;
                }
            }
        }
        return true;
    }
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
        TextWriter arch;
        arch = new StreamWriter("Assets/Data/Decks/"+input.text+".dat");
        nameDeck = input.text;
        SerializeName(nameDeck);
        SceneManager.LoadScene("EditDecksScene");
    }
    public void add()
    {
        if (validateName(input.text))
        {
            Button btn = GameObject.FindGameObjectWithTag("add").GetComponent<Button>();
            btn.interactable = true;
            string name = GameObject.FindGameObjectWithTag("nameMazo").GetComponent<InputField>().text;
            btn.onClick.AddListener(() => { TaskOnClick(); });
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        input = GameObject.FindGameObjectWithTag("nameMazo").GetComponent<InputField>();
        input.onEndEdit.AddListener(delegate { add(); });
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
    
