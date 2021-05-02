using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewLetters : MonoBehaviour
{
    public GameObject preFab2;
    public EditDeck editDeck;
    public Transform transform2;
    // Start is called before the first frame update
    void Start()
    {
    
    }
    public void aux()
    {
        editDeck = GameObject.FindGameObjectWithTag("TagA").GetComponent<EditDeck>();
        preFab2 = GameObject.FindObjectOfType<GameObject>();
        editDeck.startAux(preFab2,transform2);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
