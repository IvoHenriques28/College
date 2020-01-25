using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpVelocity;
    public bool jumping;
    public Rigidbody2D rb;
    void Start()
    {
        jumping = false;
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W) && jumping == false)
        {

            jumping = true;
            rb.velocity = Vector2.up * jumpVelocity;
        }
        
    }

}
