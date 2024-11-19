using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimator : MonoBehaviour
{
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnHoverEnter()
    {
        animator.SetTrigger("Hover");
    }

    public void OnHoverExit()
    {
        animator.SetTrigger("Idle");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
