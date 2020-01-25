using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float jumpVelocity;
    public bool jumping;
    
    public bool collisionOn;
    public MapCreator TheMap;
    
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collisionOn = true;
        
    }


    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.W) && jumping == false)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.velocity = Vector2.up * jumpVelocity;
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        if (rb.velocity.y != 0)
        {
            jumping = true;
        }
        if (rb.velocity.y == 0)
        {
            
            jumping = false;
        }
        Collision(TheMap);
    
    }

    void Collision(MapCreator map)
    {
      
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        if (map.matrix[x, y] == 1 && rb.velocity.y < 0)
        {

            
            transform.position = new Vector2(transform.position.x, y + 1.5f);
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;

        }
        if (map.matrix[x, y] == 0 && transform.position.y > 2.5f && transform.position.x >= 4.5f && transform.position.x <= 6.5f)
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
        if (map.matrix[x, y] == 0 && transform.position.y > 2.5f && transform.position.x >= 10.5f && transform.position.x <= 12.5f)
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
        if (transform.position.x <= 2.5f )
        {
            transform.position = new Vector2(2.5f, transform.position.y); 
        }
        if (transform.position.x >= 13.5f)
        {
            transform.position = new Vector2(13.5f, transform.position.y);
        }
        
    }
}
