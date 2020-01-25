using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sr;
    Rigidbody2D rb;
    public GameObject bubble;
    
    void Start()
    {

        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            sr.flipX = false;
            anim.SetBool("Walking", true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            sr.flipX = true;
            anim.SetBool("Walking", true);
        }
        if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("Walking", false);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger("Shoot");
            if(sr.flipX == true)
            {
                Instantiate(bubble, new Vector2(transform.position.x + 1f, transform.position.y), Quaternion.identity);
            }
            if (sr.flipX == false)
            {
                Instantiate(bubble, new Vector2(transform.position.x - 1f, transform.position.y), Quaternion.identity);
            }

        }
        if (rb.velocity.y > 0)
        {
            anim.SetTrigger("Jumping");
        }
        if(rb.velocity.y < 0)
        {
            anim.ResetTrigger("Jumping");
            anim.SetTrigger("Falling");
        }
        if(rb.velocity.y == 0)
        {
            anim.ResetTrigger("Falling");
            anim.SetTrigger("Idle");
        }
   
    }
 
}
