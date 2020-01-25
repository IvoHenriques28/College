using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpSpeed;
    public float fallMultiplier;
    public float jumpMultiplier;
    bool jumping;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumping==false)
        {
            rb.velocity = Vector2.up * jumpSpeed;
            jumping = true;

        }
    }
    void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (jumpMultiplier - 1) * Time.deltaTime;

        }
        else if (rb.velocity.y == 0)
        {
            jumping = false;
        }

    }
}
