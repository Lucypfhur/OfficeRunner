using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimAnimation : MonoBehaviour
{

    [SerializeField] public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("Idle");

    }

    void Update()
    {/*
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
           
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("Jump", true);
            anim.SetBool("Crouch", false);
            anim.SetBool("Idle", false);
        }
        else
        {
            anim.SetBool("Idle", true);
            anim.SetBool("Crouch", false);
            anim.SetBool("Jump", false);
        }*/
    }
}
