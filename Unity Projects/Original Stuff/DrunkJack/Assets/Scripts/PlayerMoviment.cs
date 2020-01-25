using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{

    public float speed;
    public float jumpVelocity;
    public bool jumping;
    public Rigidbody2D rb;
    float JumpSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumping = false;
        JumpSpeed = 0.05f;
    }

    
    void Update()
    {
        
      
        if(transform.position.y < -4f)
        {
            transform.position = new Vector2(transform.position.x, -4);
            jumping = false;
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        if (Input.GetButtonUp("Jump"))
        {
            rb.gravityScale = 19999/20000;
            rb.velocity = Vector2.up * jumpVelocity;
            jumping = true;
            
        }

        transform.Translate(Vector2.right * speed);

        if (rb.velocity.y < 0)
        {
            transform.Translate(Vector2.right * speed* 0.1f);
        }
        }
}
