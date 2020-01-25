using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sr;
    

    bool isCrouched;
    bool punching;
    bool kicking;
    bool jumping;
    
    

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        

    }

    public void StopAnim()
    {
        anim.speed = 0;
    }

    public void ResetTriggers()
    {
        Debug.Log("Reseted");

        anim.ResetTrigger("WalkTrig");
        anim.ResetTrigger("StandKick");
        anim.ResetTrigger("StandPunch");
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            sr.flipX = false;
            ResetTriggers();
            anim.speed = 1;
            anim.SetTrigger("WalkTrig");
          
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            kicking = true;
            if (isCrouched == true)
            {
                anim.speed = 1;
                anim.SetTrigger("CrouchKick");
            }
            if (jumping == true)
            {
                anim.speed = 1;
                anim.SetTrigger("JumpKick");
            }

            else if (isCrouched == false && jumping == false)
            {

                anim.speed = 1;
                anim.SetTrigger("StandKick");
            }
            
        }
      
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            sr.flipX = true;
            ResetTriggers();
            anim.speed = 1;
            anim.SetTrigger("WalkTrig");
            
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            punching = true;
            if(isCrouched == true)
            {
                anim.speed = 1;
                anim.SetTrigger("CrouchPunch");
            }
            if (jumping == true)
            {
                anim.speed = 1;
                anim.SetTrigger("JumpPunch");
            }
            else if (isCrouched == false)
            {
               
                anim.speed = 1;
                anim.SetTrigger("StandPunch");
            }
        }
        if(Input.anyKey == false && kicking == false && punching == false )
        {
            anim.speed = 0;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isCrouched = true;
            anim.SetTrigger("Squat");
            anim.ResetTrigger("WalkTrig");
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);


        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            isCrouched = false;
            anim.ResetTrigger("Squat");
            anim.ResetTrigger("CrouchKick");
            anim.ResetTrigger("CrouchPunch");
            anim.SetTrigger("WalkTrig");
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
        }
        if (rb.velocity.y > 0 )
        {
            jumping = true;
            rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
            anim.speed = 1;
            anim.ResetTrigger("WalkTrig");
            anim.SetTrigger("Jump");
        }
        if(transform.position.y <= -0.5 && rb.velocity.y < 0)
        {
            transform.position = new Vector2(transform.position.x, -0.5f);
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            


        }
        if (rb.velocity.y < 0)
        {
            anim.ResetTrigger("Jump");
            anim.SetTrigger("Fall");
        }
        if(rb.velocity.y == 0)
        {
            
            jumping = false;
            anim.ResetTrigger("Fall");
            anim.SetTrigger("WalkTrig");
        }
     
       
       









    }
}
