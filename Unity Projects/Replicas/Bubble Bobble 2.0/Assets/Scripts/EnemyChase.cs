using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float speed;
    public float lowJumpMultiplier = 2f;
    public float fallMultiplier = 2.5f;
    public float jumpVelocity;
    public int timer;
    SpriteRenderer sr;
    Rigidbody2D rb;
    private Transform target;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    
    void Update()
    {
        timer = timer + 1;
        var targetPos = new Vector2(target.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if(transform.position.x - target.position.x > 0)
        {
            sr.flipX = false;
        }
        if (transform.position.x - target.position.x < 0)
        {
            sr.flipX = true;
        }
        if(transform.position.y - target.position.y < -1.5f)
        {
            EnemyJump();
        }
        if(timer >= 600)
        {
            speed = 2;
        }
        
    }

    void EnemyJump()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        
        rb.velocity = Vector2.up * jumpVelocity;
        
        
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 )
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
