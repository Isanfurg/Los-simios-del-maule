using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] AnimatorControllerParameter animatorController;
    [SerializeField] int thisIndex;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (menuButtonController.index == thisIndex)
        {
            animator.SetBool("Highlighted",true)
        }
    }
}
