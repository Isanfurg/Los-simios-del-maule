using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerLife : MonoBehaviour
{
    public float playerLife;
    public float playerLifeNow;
    public List<int> cardsLife;
    public Image LifeP1;
    // Start is called before the first frame update
    public void attackOfPlayer(int damage)
    {
        playerLifeNow -= damage;
        
    }
    void Start()
    {
         playerLifeNow= playerLife = 4000;
    }

    // Update is called once per frame
    void Update()
    {
        LifeP1.fillAmount = playerLifeNow / playerLife;
    }
}
