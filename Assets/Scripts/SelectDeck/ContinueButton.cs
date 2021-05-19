using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Clase para controlar el bot�n de continuar en la escena "SelectDeckScene"
public class ContinueButton : MonoBehaviour
{
    public Text Alert;

    //Bot�n para continuar al juego. Valida que se haya seleccionado un mazo antes de continuar al juego
   public void Continue(string scene)
    {
        if(DeckClick.selectedDeck != null)
        {
            SceneManager.LoadScene(scene);
        }
        else
        {
            Alert.text = "Debe seleccionar un mazo";
        }
    }

}
