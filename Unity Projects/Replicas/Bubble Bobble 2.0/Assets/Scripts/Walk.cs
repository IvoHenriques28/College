using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Animator anim;
 
    void Start()
    {
        anim.GetComponent<Animator>();
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
