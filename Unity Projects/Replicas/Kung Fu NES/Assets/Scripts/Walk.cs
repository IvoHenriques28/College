using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
   
    Rigidbody2D rb;
    public float speed;
    public float jumpSpeed;
    private float fallMultiplier = 2.5f;
    private float jumpMultiplier = 2f;
    
    
    void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       
    }
    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * speed);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(Vector2.left * speed);

        }
   


    }
}
