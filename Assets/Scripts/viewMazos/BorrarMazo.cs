using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using UnityEngine;

public class BorrarMazo : MonoBehaviour
{
    public void borrar()
    {
        string nameBtn;
        List<string> names = new List<string>();
        using (StreamReader leer = new StreamReader("Assets/Data/ultimoMazo.txt"))
        {
            nameBtn = leer.ReadLine();
        }
        using (StreamReader leer = new StreamReader("Assets/Data/Dekcsnames.txt"))
        {
            while (!leer.EndOfStream)
            {
                string line = leer.ReadLine();
                if (!line.Equals(nameBtn))
                {
                    names.Add(line);
                }
            }
        }

        using (StreamWriter esc = new StreamWriter("Assets/Data/Dekcsnames.txt"))
        {
            foreach (string s in names)
            {
                esc.WriteLine(s);
            }

        }
        
        File.Delete("Assets/Data/Decks/"+ nameBtn+".dat");
        //File.Delete("Assets/Data/Decks/" + nameBtn + ".meta.dat");
    }
   
}
