using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveForce;
    public float distance;
    private Animator anim;
    public GameObject explosion;
    private Rigidbody2D rb;
    public Vector2 moveDir;
    public int offset;
    
    private int i;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveDir = ChooseDirection();
    }

    
    void Update()
    {
        
        rb.velocity = moveDir * moveForce;
        if( MapCreator.matrix[Mathf.RoundToInt(transform.position.x - 0.4f)+ offset, Mathf.RoundToInt(transform.position.y)] > 0 && i == 0 && MapCreator.matrix[Mathf.RoundToInt(transform.position.x - 0.4f) + offset, Mathf.RoundToInt(transform.position.y)] < 4)
        {
            moveDir = ChooseDirection();
        }
        else if (MapCreator.matrix[Mathf.RoundToInt(transform.position.x + 0.4f) - offset, Mathf.RoundToInt(transform.position.y)] > 0 && i == 2 && MapCreator.matrix[Mathf.RoundToInt(transform.position.x + 0.4f) - offset, Mathf.RoundToInt(transform.position.y)] < 4)
        {
           
            moveDir = ChooseDirection();
        }
        else if (MapCreator.matrix[Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y) + offset] > 0 && i == 3 && MapCreator.matrix[Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y) + offset] < 4)
        {
            moveDir = ChooseDirection();
        }
        else if (MapCreator.matrix[Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y) - offset] > 0 && i == 1 && MapCreator.matrix[Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y) - offset] < 4)
        {
            moveDir = ChooseDirection();
        }
        explosion = GameObject.FindGameObjectWithTag("Explosion");
        if(explosion != null)
        {
            distance = Vector2.Distance(transform.position, explosion.transform.position);
        }
        if (distance < 1)
        {
            Destroy(gameObject);
        }
    }
    void ResetTriggers()
    {
        anim.ResetTrigger("WalkRight");
        anim.ResetTrigger("WalkLeft");
        anim.ResetTrigger("WalkUp");
        anim.ResetTrigger("WalkDown");
    }

    Vector2 ChooseDirection()
    {
        System.Random rand = new System.Random();
         i = rand.Next(0, 3);
        Vector2 temp = new Vector2();

        if(i == 0)
        {
            temp = transform.right;
            ResetTriggers();
            anim.SetTrigger("WalkRight");
        }
        if (i == 1)
        {
            temp = -transform.up;
            ResetTriggers();
            anim.SetTrigger("WalkDown");
        }
        if (i == 2)
        {
            temp =-transform.right;
            ResetTriggers();
            anim.SetTrigger("WalkLeft");
        }
        if (i == 3)
        {
            temp = transform.up;
            ResetTriggers();
            anim.SetTrigger("WalkUp");
        }
        return temp;
    }
}
