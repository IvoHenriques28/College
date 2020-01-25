using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public GameObject target;
    public int percentage;
    private int jumpCount;
    private bool punch;
    private bool teste = false;
    public GameObject apples;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = target.GetComponent<Rigidbody2D>();
        jumpCount = 0;
    }
   

    void Update()
    {
        punch = false;
        
        percentage = Random.Range(0, 1000);
            if (percentage == 1 && target.transform.position.y == -4)
        {
            anim.SetTrigger("DrunkRun");
           // anim.SetTrigger("Fall");

        }
        else
        {
            anim.ResetTrigger("DrunkRun");
        }
        anim.ResetTrigger("JumpUp");
        if (rb.velocity.y > 0 )
        {
            
            anim.SetTrigger("JumpUp");
          
            
        }
       
        if (rb.velocity.y < -1)
        {
            if (teste == false)
            {
                anim.SetBool("GoDown", true);
            }
            if (rb.position.y <= -4)
            {
                anim.ResetTrigger("JumpDown");
            }
            else
            {
                if (teste == false)
                {
                    anim.SetTrigger("JumpDown");
                    
                }
                
            }
            
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("Crouch", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("Crouch", false);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Punch");
            punch = true;
        }
        if (transform.position.y < -4)
        {
            jumpCount = 0;
        }

        if (transform.position.y > -3.5 && teste == false)
        {
             anim.SetBool("OnTheAir", true);

        }
        else
        {
            anim.SetBool("OnTheAir", false);
            
            anim.ResetTrigger("JumpDown");

        }
        teste = false;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "barreira")
        {

            anim.SetBool("GoDown", false);
            anim.SetBool("OnTheAir", false);
           // anim.ResetTrigger("JumpDown");
            teste = true;
            Debug.Log("1");
            anim.SetTrigger("Fall");

        }
        if (other.gameObject.tag == "chao")
        {
            anim.SetBool("GoDown", false);
            anim.SetBool("OnTheAir", false);
            teste = true;
        }
        if (other.gameObject.tag == "maca" && punch == true)
        {
            Destroy(other.gameObject);
            
            Instantiate(apples, new Vector2(rb.transform.position.x + 3, rb.transform.position.y + 2), Quaternion.identity);
            Instantiate(apples, new Vector2(rb.transform.position.x + 4, rb.transform.position.y + 2), Quaternion.identity);
            Instantiate(apples, new Vector2(rb.transform.position.x + 5, rb.transform.position.y + 2), Quaternion.identity);
            Instantiate(apples, new Vector2(rb.transform.position.x + 6, rb.transform.position.y + 2), Quaternion.identity);

        }
            Debug.Log(punch);

    }




}
