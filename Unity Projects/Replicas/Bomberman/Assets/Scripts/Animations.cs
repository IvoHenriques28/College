using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private Animator anim;
   
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            anim.speed = 1;
            anim.SetTrigger("WalkingUp");
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            anim.ResetTrigger("WalkingUp");
            anim.speed = 0;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.speed = 1;
            anim.SetTrigger("WalkingDown");
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            anim.ResetTrigger("WalkingDown");
            anim.speed = 0;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            
            anim.speed = 1;
            anim.SetTrigger("WalkingRight");
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            anim.ResetTrigger("WalkingRight");
            anim.speed = 0;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
           
            anim.speed = 1;
            anim.SetTrigger("WalkingLeft");
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            anim.ResetTrigger("WalkingLeft");
            anim.speed = 0;
        }
    }
}
