using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.anyKey)
        {
            anim.SetTrigger("Idle");
        }
        else
        {
            anim.ResetTrigger("Idle");
        }

        if(Input.GetAxisRaw("Horizontal") == 1)
            {

                rb.velocity = new Vector2(speed, rb.velocity.y);
                anim.Play("Forward");
            }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            anim.Play("Back");
        }
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
