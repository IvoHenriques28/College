using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStuff : MonoBehaviour
{
    public int timer;
    public bool collisionOn;
    public bool trapped;
    public MapCreator TheMap;
    Animator anim;
    Rigidbody2D rb;
    private Transform target;
    
    void Start()
    {
        trapped = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        collisionOn = true;
        
    }

    
    void Update()
    {
        
        timer = timer + 1;
        Collision(TheMap);
        target = GameObject.FindGameObjectWithTag("Bubble").GetComponent<Transform>();
        
        
        if (timer >= 600 && trapped == false) 
        {
            
            anim.SetTrigger("Angry");
        }
        
        if(transform.position.x - target.position.x <= 1 && transform.position.y - target.position.y <= 1)
        {
            trapped = true;
            Destroy(target.gameObject);
            GetComponent<EnemyChase>().enabled = false;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.gravityScale = -0.05f;
            anim.SetTrigger("Traped");
        }
      

        
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
        if (transform.position.x <= 2.5f)
        {
            transform.position = new Vector2(2.5f, transform.position.y);
        }
        if (transform.position.x >= 13.5f)
        {
            transform.position = new Vector2(13.5f, transform.position.y);
        }

    }
    
       
     
    
}
