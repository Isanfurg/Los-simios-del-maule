using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerLife : MonoBehaviour
{
    public static float playerLife;
    public static float playerLifeNow;
    public List<int> cardsLife;
    
    // Start is called before the first frame update
   
    void Start()
    {  
         playerLifeNow= playerLife = 4000;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
