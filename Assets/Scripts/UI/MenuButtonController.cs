using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    public int index;
    [SerializeField] bool keyDown;
    [SerializeField] int maxIndex;
    public AudioSource audioS;
    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            if (!keyDown)
            {
                if (Input.GetAxis("Vertical") < 0)
                {
                    if (index < maxIndex){   index++;    }
                    else{ index = 0; }
                } else if (Input.GetAxis("Vertical") > 0)
                {
                    if(index > 0) { index--; }
                    else { index = maxIndex; }
                }
            }

        }
        else
        {
            keyDown = true;
        }
    }
}