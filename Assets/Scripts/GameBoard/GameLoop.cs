using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.GameBoard;


public class GameLoop : MonoBehaviour
{
    // Start is called before the first frame update

    List<Duelist> duelists;
    void Start()
    {
        duelists = new List<Duelist>();
        duelists.Add(new Duelist());
        duelists.Add(new Duelist());
        //select order start
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
